var builder = WebApplication.CreateBuilder(args);

//Add Service for container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

//Configure the HTTP request Pipeline
app.MapCarter();

app.Run();
