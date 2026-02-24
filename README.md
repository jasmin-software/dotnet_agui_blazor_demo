# Blazor Demo

This demo consists of an **AG-UI server hosting an AI agent** and a **Blazor client** that connects to the server and displays streaming responses from the agent. The agent can call tools to change background color, enable/disable verbose logging, and request user approval before creating a text file.

> [!NOTE]
> You'll need a **GitHub Personal Access Token** (PAT) to run this application.
>
> If you don't have one yet, go to [Create a GitHub Personal Access Token (PAT)](https://github.com/jasmin-software/dotnet_agui_workshop/tree/main/0.%20GitHub%20Token) to create it.

## Configuration

Follow these steps to run the demo:

In the `Server` directory, create a file named `appsettings.Development.json` with the following content:

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

You have two options to run the project:
- Manually run the server followed by the client, or
- Use Aspire to run both the server and client simultaneously.

## Option 1: Manually run the server and client

From the `Server` folder:

```bash
dotnet run --urls http://localhost:5000
```

In a new terminal, from the `Client` folder:

```bash
dotnet run watch
```

You should see the Blazor client interface in your default browser.

## Option 2: Use Aspire to run both the server and client simultaneously

- Install Aspire if you haven't already by following the instructions in the [Aspire documentation](https://aspire.dev/get-started/install-cli/).

- Open a terminal and navigate to the root directory of the project. Run the following command to start both the server and client using Aspire:

```bash
aspire run
```

This command will start both the server and client, and you should see the output in the terminal. Copy the URL provided in the terminal for the `Dashboard` and paste it into a browser. 

When the Aspire dashboard opens, click on the `Blazor` URL to open the Blazor client in a new browser tab. You should see the Blazor client interface where you can interact with the AI agent.
