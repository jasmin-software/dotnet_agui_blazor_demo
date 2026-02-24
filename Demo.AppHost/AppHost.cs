var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.Server>("server");

var blazor = builder.AddProject<Projects.Client>("blazor")
    .WithEnvironment("AGUI_SERVER_URL", server.GetEndpoint("http"));
builder.Build().Run();
