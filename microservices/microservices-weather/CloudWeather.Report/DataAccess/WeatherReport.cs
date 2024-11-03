namespace CloudWeather.Report.DataAccess;

public class WeatherReport
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal AverageLowC { get; set; }
    public decimal AverageHighC { get; set; }
    public decimal RainfallTotalCentimetres { get; set; }
    public decimal SnowTotalCentimetres { get; set; }
    public string PostCode { get; set; }
}