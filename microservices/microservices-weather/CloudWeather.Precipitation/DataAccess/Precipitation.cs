namespace CloudWeather.Precipitation.DataAccess;

public class Precipitation
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal Centimetres { get; set; }
    public string WeatherType { get; set; }
    public string PostCode { get; set; }
}