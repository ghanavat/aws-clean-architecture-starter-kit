using Ghanavats.CleanArchitecture.Api.DependencyInjection;
using Ghanavats.CleanArchitecture.Api.HealthChecks;
using Ghanavats.CleanArchitecture.Api.Middleware;
using Ghanavats.CleanArchitecture.UseCases.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidators();
builder.Services.AddUseCases();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi("aws_cleanArchitecture_starterKit");

builder.Services.AddHostedService<StartupBackgroundService>();
builder.Services.AddSingleton<StartupHealthCheck>();
builder.Services.AddHealthChecks().AddCheck<StartupHealthCheck>("startup_health_check" , tags: ["ready"]);

builder.Services.AddExceptionHandler<ExceptionHandlerMiddleware>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        // If you want to customise how ProblemDetails is defined and put together.
    };
});

var app = builder.Build();

app.UseExceptionHandler();
app.RegisterEndpoints();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = healthCheck => healthCheck.Tags.Contains("ready")
});
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => false
});

await app.RunAsync();
