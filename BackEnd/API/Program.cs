using api.MiddleWares;
using api.StartupConfigurations;
using persistance.Seed;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationServices(builder.Configuration);

var app = builder.Build();
if (app.Environment.EnvironmentName.ToLower() == "Development")
{
    await using var scope = app.Services.CreateAsyncScope();
    await scope.ServiceProvider.GetRequiredService<SeedService>().SeedAsync();
}
app.RegisterApplicationMiddleWares();

