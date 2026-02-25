using System.ClientModel;
using Microsoft.Agents.AI.Hosting.AGUI.AspNetCore;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Chat;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient().AddLogging();
builder.Services.AddAGUI();
var app = builder.Build();

string? apiKey = builder.Configuration["GitHub:Token"];
string? endpoint = builder.Configuration["GitHub:ApiEndpoint"] ?? "https://models.github.ai/inference";
string? deploymentName = builder.Configuration["GitHub:Model"] ?? "openai/gpt-4o-mini";

// Create AI agent
ChatClient chatClient = new OpenAIClient(
    new ApiKeyCredential(apiKey!),
    new OpenAIClientOptions()
    {
        Endpoint = new Uri(endpoint)
    })
    .GetChatClient(deploymentName);

var assistantAgent = chatClient.CreateAIAgent(instructions: @"
    You are a professional productivity assistant that helps manage my workspace.");

var friendlyAgent = chatClient.CreateAIAgent(instructions: @"
    You are a good friend who is bubbly, speaks casually, and uses with a lot of emojis. You provide support and encouragement.");

// Map the AG-UI agent endpoint
app.MapAGUI("/assistant", assistantAgent);
app.MapAGUI("/friend", friendlyAgent);

app.Run();