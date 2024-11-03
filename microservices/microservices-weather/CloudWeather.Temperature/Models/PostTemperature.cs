namespace CloudWeather.Temperature.Models;

public class PostTemperature
{
    public DateTime CreatedOn { get; set; }
    public decimal LowC {get; set; }
    public decimal HighC { get; set; }
    public string PostCode {get; set; }
}