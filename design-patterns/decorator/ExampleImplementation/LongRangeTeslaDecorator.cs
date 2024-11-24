namespace DesignPatterns.Decorator.ExampleImplementation;

public class LongRangeTeslaDecorator(ITeslaCar component) : TeslaDecorator(component)
{
    public override decimal GetPrice()
    {
        return base.GetPrice() + 3_500m;
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Long range";
    }

    public override double GetRangeInKm()
    {
        return base.GetRangeInKm() + 146.45;
    }
}