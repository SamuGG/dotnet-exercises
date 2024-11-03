namespace CloudWeather.Temperature.DataAccess;

public class Temperature
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal HighC { get; set; }
    public decimal LowC{ get; set; }
    public string PostCode { get; set; }
}