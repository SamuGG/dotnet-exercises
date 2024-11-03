using CloudWeather.Report.BusinessLogic;
using CloudWeather.Report.Config;
using CloudWeather.Report.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IWeatherReportAggregator, WeatherReportAggregator>();
builder.Services.Configure<WeatherDataConfig>(builder.Configuration.GetSection("WeatherDataConfig"));

builder.Services.AddDbContext<WeatherReportDbContext>(
    options => 
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
    }, 
    ServiceLifetime.Transient);

var app = builder.Build();

app.MapGet("/weather-report/{postCode}", async (string postCode, [FromQuery] int? days, IWeatherReportAggregator aggregator) => 
{
    if (days is null || days < 1 || days > 30)
        return Results.BadRequest($"Please provide a {nameof(days)} query parameter between 1 and 30");
    
    return Results.Ok(await aggregator.BuildWeeklyReport(postCode, days.Value));
});

app.Run();