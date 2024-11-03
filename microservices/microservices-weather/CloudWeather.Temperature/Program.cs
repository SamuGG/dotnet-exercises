using CloudWeather.Temperature.DataAccess;
using CloudWeather.Temperature.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TemperatureDbContext>(
    options => 
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
    }, 
    ServiceLifetime.Transient);

var app = builder.Build();

app.MapGet("/observation/{postCode}", async (string postCode, [FromQuery] int? days, TemperatureDbContext dbContext) => {
    if (days is null || days < 0 || days > 30)
        return Results.BadRequest($"Please provide a '{nameof(days)}' parameter between 1 and 30");

    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);
    var results = await dbContext.Temperature
        .Where(record => record.PostCode == postCode && record.CreatedOn > startDate)
        .ToListAsync();

    return Results.Ok(results);
});

app.MapPost("/observation", async (PostTemperature model, TemperatureDbContext dbContext) => {
    var entity = new Temperature
    {
        CreatedOn = model.CreatedOn.ToUniversalTime(),
        LowC = model.LowC,
        HighC = model.HighC,
        PostCode = model.PostCode
    };
    await dbContext.AddAsync(entity);
    await dbContext.SaveChangesAsync();
});

app.Run();