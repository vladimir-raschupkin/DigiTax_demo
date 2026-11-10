var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.DigiTax_demo_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.AddProject<Projects.DigiTax_demo_Blazor>("digitax-demo-blazor");

builder.Build().Run();
