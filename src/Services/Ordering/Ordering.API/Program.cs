using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add service to the container

//------------------
//Infrastructure - EF core
//Application  - MediatR
//API - Carter, HealthChecks,....

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();
//----------------------
var app = builder.Build();

// Configulation the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
