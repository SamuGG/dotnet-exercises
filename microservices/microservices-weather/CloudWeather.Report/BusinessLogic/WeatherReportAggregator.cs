using System.Text.Json;
using CloudWeather.Report.Config;
using CloudWeather.Report.DataAccess;
using CloudWeather.Report.Models;
using Microsoft.Extensions.Options;

namespace CloudWeather.Report.BusinessLogic;

public class WeatherReportAggregator : IWeatherReportAggregator
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<WeatherReportAggregator> _logger;
    private readonly WeatherReportDbContext _dbContext;
    private readonly WeatherDataConfig _config;

    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public WeatherReportAggregator(
        IHttpClientFactory clientFactory, 
        ILogger<WeatherReportAggregator> logger, 
        WeatherReportDbContext dbContext, 
        IOptions<WeatherDataConfig> config)
    {
        _clientFactory = clientFactory;
        _logger = logger;
        _dbContext = dbContext;
        _config = config.Value;
    }

    public async Task<WeatherReport> BuildWeeklyReport(string postCode, int days)
    {
        var client = _clientFactory.CreateClient();
        var precipitationData = await FetchPrecipitationData(client, postCode, days);
        var temperatureData = await FetchTemperatureData(client, postCode, days);

        decimal totalRain = GetTotalPrecipitationAmount(precipitationData, "rain");
        decimal totalSnow = GetTotalPrecipitationAmount(precipitationData, "snow");

        decimal averageHighTemperature = GetAverageTemperature(temperatureData, x => x.HighC);
        decimal averageLowTemperature = GetAverageTemperature(temperatureData, x => x.LowC);

        _logger.LogInformation($"Post code {postCode} over last {days} days: total rain = {totalRain} cm, total snow = {totalSnow} cm, low temp = {averageLowTemperature} C, high temp = {averageHighTemperature} C");

        var weatherReport = new WeatherReport
        {
            AverageLowC = averageLowTemperature,
            AverageHighC = averageHighTemperature,
            RainfallTotalCentimetres = totalRain,
            SnowTotalCentimetres = totalSnow,
            CreatedOn = DateTime.UtcNow,
            PostCode = postCode
        };

        await _dbContext.AddAsync(weatherReport);
        await _dbContext.SaveChangesAsync();

        return weatherReport;
    }

    private async Task<IEnumerable<TemperatureModel>> FetchTemperatureData(HttpClient client, string postCode, int days)
    {
        var endpoint = BuildTemperatureServiceEndpoint(postCode, days);
        var temperatureData = await client.GetFromJsonAsync<IEnumerable<TemperatureModel>>(endpoint, JsonOptions);
        return temperatureData ?? Array.Empty<TemperatureModel>();
    }

    private async Task<IEnumerable<PrecipitationModel>> FetchPrecipitationData(HttpClient client, string postCode, int days)
    {
        var endpoint = BuildPrecipitationServiceEndpoint(postCode, days);
        var precipitationData = await client.GetFromJsonAsync<IEnumerable<PrecipitationModel>>(endpoint, JsonOptions);
        return precipitationData ?? Array.Empty<PrecipitationModel>();
    }

    private string BuildPrecipitationServiceEndpoint(string postCode, int days) =>
        $"{_config.PrecipitationServiceScheme}://{_config.PrecipitationServiceHost}:{_config.PrecipitationServicePort}/observation/{postCode}?days={days}";

    private string BuildTemperatureServiceEndpoint(string postCode, int days) =>
        $"{_config.TemperatureServiceScheme}://{_config.TemperatureServiceHost}:{_config.TemperatureServicePort}/observation/{postCode}?days={days}";

    private static decimal GetTotalPrecipitationAmount(IEnumerable<PrecipitationModel> precipitationData, string weatherTypeSelector) => 
        Math.Round(
            precipitationData
                .Where(x => string.Equals(x.WeatherType, weatherTypeSelector, StringComparison.InvariantCultureIgnoreCase))
                .Sum(x => x.Centimetres),
            1);

    private static decimal GetAverageTemperature(IEnumerable<TemperatureModel> temperatureData, Func<TemperatureModel, decimal> fieldSelector) =>
        Math.Round(temperatureData.Average(fieldSelector), 1);
}