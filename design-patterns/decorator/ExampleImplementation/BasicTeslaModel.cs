namespace DesignPatterns.Decorator.ExampleImplementation;

public class BasicTeslaModel : ITeslaCar
{
    public string GetDescription()
    {
        return "Tesla Model 3 Rear-Wheel Drive";
    }

    public decimal GetPrice()
    {
        return 38_990m;
    }

    public double GetRangeInKm()
    {
        return 437.74;
    }
}