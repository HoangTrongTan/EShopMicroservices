var builder = WebApplication.CreateBuilder(args);
// Add Services to the container

var app = builder.Build();

// Config the http request pipeline

app.Run();
