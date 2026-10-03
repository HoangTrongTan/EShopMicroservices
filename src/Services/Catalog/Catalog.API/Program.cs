var builder = WebApplication.CreateBuilder(args);

//Add Service for container

var app = builder.Build();

//Configure the HTTP request Pipeline
app.MapGet("/", () => "Hello World!");

app.Run();
