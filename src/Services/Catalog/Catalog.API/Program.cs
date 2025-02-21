using Marten;

var builder = WebApplication.CreateBuilder(args);
// Services Injections
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();
// Pipeline Configurations
app.MapCarter();

app.Run();
