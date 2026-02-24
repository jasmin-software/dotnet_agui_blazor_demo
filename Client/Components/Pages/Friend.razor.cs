using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.AI;


namespace Client.Components.Pages;

public partial class Friend(AgentCollection agentCollection)
{
    private string CurrentMessage = "";
     private List<ChatText> Messages = new ();


    public class ChatText
    {
        public required string Text { get; set; }
        public bool IsUser { get; set; }
    }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(1000);
        Messages.Add(new ChatText
            {
                Text = @"
### Hi friend! 🙂

I'm here to chat and keep you company. Whether you want to talk about your day, share some jokes, or just need someone to listen, I'm all ears!",
                IsUser = false
            });
    }

    private async Task SendMessage()
    {
        if (!string.IsNullOrWhiteSpace(CurrentMessage))
        {
            var userMessage = new ChatText
            {
                Text = CurrentMessage,
                IsUser = true
            };

            Messages.Add(userMessage);

            var userText = CurrentMessage;
            CurrentMessage = "";

            Messages.Add(new ChatText
            {
                Text = "",
                IsUser = false
            });

            await foreach (var update in agentCollection.FriendlyAgent.RunStreamingAsync(userText))
            {
                foreach (var content in update.Contents)
                {
                    if (content is TextContent textContent)
                    {
                        Messages.Last().Text += textContent.Text;
                        StateHasChanged();
                    }
                }
            }
        }
    }

    private string RenderMarkdown(string markdown)
    {
        return Markdig.Markdown.ToHtml(markdown);
    }

    private async Task HandleKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" 
            && !string.IsNullOrWhiteSpace(CurrentMessage))
        {
            await SendMessage();
        }
    }
}