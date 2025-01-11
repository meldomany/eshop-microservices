var builder = WebApplication.CreateBuilder(args);
// Services Injections
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();
// Pipeline Configurations
app.MapCarter();

app.Run();
