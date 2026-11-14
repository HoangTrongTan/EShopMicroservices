var builder = WebApplication.CreateBuilder(args);
// Add Services to the container
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Config the http request pipeline
app.MapReverseProxy();

app.Run();
