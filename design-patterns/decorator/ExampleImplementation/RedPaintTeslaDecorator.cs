namespace DesignPatterns.Decorator.ExampleImplementation;

public class RedPaintTeslaDecorator(ITeslaCar car) : TeslaDecorator(car)
{
    public override decimal GetPrice()
    {
        return base.GetPrice() + 2_000m;
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Red paint";
    }
}