using System.Net.Http.Json;
using CloudWeather.DataLoader.Models;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    // .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()
    .Build();

var servicesConfig = config.GetSection("Services");

var temperatureServiceConfig = servicesConfig.GetSection("Temperature");
var precipitationServiceConfig = servicesConfig.GetSection("Precipitation");

var PostCodes = new string[] 
{
    "M14DU",
    "M128FH",
    "M62AP",
    "M76WB",
    "M225TT"
};

Console.WriteLine("Starting data load");

var temperatureClient = new HttpClient
{
    BaseAddress = new Uri($"http://{temperatureServiceConfig["Host"]}:{temperatureServiceConfig["Port"]}")
};

var precipitationClient = new HttpClient
{
    BaseAddress = new Uri($"http://{precipitationServiceConfig["Host"]}:{precipitationServiceConfig["Port"]}")
};

foreach (string postCode in PostCodes)
{
    Console.WriteLine($"Processing post code {postCode}");

    var dateFrom = DateTime.Today.AddDays(-30);
    var dateTo = DateTime.Today;

    for (var day = dateFrom.Date; day.Date <= dateTo.Date; day = day.AddDays(1))
    {
        (int lowTemperature, int highTempereature) = PostTemperature(postCode, day, temperatureClient).Result;
        PostPrecipitation(lowTemperature, postCode, day, precipitationClient).GetAwaiter().GetResult();
    }
}

async Task PostPrecipitation(int lowTemperature, string postCode, DateTime day, HttpClient httpClient)
{
    var random = new Random();
    bool isPrecipitation = random.Next(2) < 1;

    PrecipitationModel observation = isPrecipitation ? 
        new PrecipitationModel(day, random.Next(1, 41), lowTemperature <= 0 ? "snow" : "rain", postCode) :
        observation = new PrecipitationModel(day, 0, "none", postCode);

    var clientResponse = await httpClient.PostAsJsonAsync("observation", observation).ConfigureAwait(false);
    if (clientResponse.IsSuccessStatusCode)
        Console.WriteLine($"Posted precipitation for date {observation.CreatedOn:d}, post code {observation.PostCode}, type {observation.WeatherType}, amount {observation.Centimetres} cm");
}

async Task<(int, int)> PostTemperature(string postCode, DateTime day, HttpClient httpClient)
{
    var random = new Random();
    var temperature1 = random.Next(-1, 29);
    var temperature2 = random.Next(-1, 29);

    if (temperature2 < temperature1)
    {
        temperature1 ^= temperature2;
        temperature2 ^= temperature1;
        temperature1 ^= temperature2;
    }

    var observation = new TemperatureModel(day, temperature1, temperature2, postCode);
    var clientResponse = await httpClient.PostAsJsonAsync("observation", observation);
    if (clientResponse.IsSuccessStatusCode)
        Console.WriteLine($"Posted temperature for date {observation.CreatedOn:d}, post code {observation.PostCode}, low {observation.LowC} C, high {observation.HighC} C");

    return (temperature1, temperature2);
}