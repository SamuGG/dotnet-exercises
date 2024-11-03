namespace CloudWeather.Precipitation.Models;

public class PostPrecipitation
{
    public DateTime CreatedOn { get; set; }
    public decimal Centimetres {get; set; }
    public string WeatherType { get; set; }
    public string PostCode { get; set; }
}