namespace CloudWeather.DataLoader.Models;

internal record PrecipitationModel(DateTime CreatedOn, decimal Centimetres, string WeatherType, string PostCode);