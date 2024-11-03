namespace CloudWeather.DataLoader.Models;

internal record TemperatureModel(DateTime CreatedOn, decimal LowC, decimal HighC, string PostCode);