using CloudWeather.Report.DataAccess;

namespace CloudWeather.Report.BusinessLogic;

public interface IWeatherReportAggregator
{
    Task<WeatherReport> BuildWeeklyReport(string postCode, int days);
}