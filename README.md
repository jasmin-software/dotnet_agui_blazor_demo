# Blazor Demo

This demo consists of an AG-UI server hosting an AI agent and a Blazor client that connects to the server and displays streaming responses from the agent. The agent can call tools to change background color, and request user approval before creating a text file.

Follow these steps to run the demo:

1. [Create a GitHub Personal Access Token (PAT)](https://github.com/jasmin-software/dotnet_agui_workshop/tree/main/0.%20GitHub%20Token
2. Create a file named `appsettings.Development.json` in the `Server` directory with the following content:

```json
{ 
  "GitHub": {
    "Token": "put-your-github-personal-access-token-here",
    "ApiEndpoint": "https://models.github.ai/inference",
    "Model": "openai/gpt-4o-mini"
  }
}
```

> [!NOTE]
>
> Replace _put-your-github-personal-access-token-here_ with your GitHub Personal Access Token. 

3. You have two options to run the project. The first option is to manually run the server followed by the client. The second option is to use Aspire to run both the server and client simultaneously.

### Option 1: Manually run the server and client

- Open a terminal and navigate to the `Server` directory. Run the following command to start the server:

```bash
dotnet run --urls http://localhost:5000
```
- Open another terminal and navigate to the `Client` directory. Run the following command to start the Blazor client:

```bash
dotnet run watch
```

You should see the Blazor client interface in your default browser.

### Option 2: Use Aspire to run both the server and client simultaneously

- Install Aspire if you haven't already by following the instructions in the [Aspire documentation](https://aspire.dev/get-started/install-cli/).

- Open a terminal and navigate to the root directory of the project. Run the following command to start both the server and client using Aspire:

```bash
aspire run
```
This command will start both the server and client, and you should see the output in the terminal. Copy the URL provided in the terminal for the `Dashboard` and paste it into a browser. 

When the Aspire dashboard opens, click on the `Blazor` URL to open the Blazor client in a new browser tab. You should see the Blazor client interface where you can interact with the AI agent.
