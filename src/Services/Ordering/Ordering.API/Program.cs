var builder = WebApplication.CreateBuilder(args);

// Add service to the container

//------------------
//Infrastructure - EF core
//Application  - MediatR
//API - Carter, HealthChecks,....

//builder.Services
//    .AddApplicationService()
//    .AddInfrastructureService(builder.Configuration)
//    .AddWebService();
//----------------------
var app = builder.Build();

// Configulation the HTTP request pipeline

app.Run();
