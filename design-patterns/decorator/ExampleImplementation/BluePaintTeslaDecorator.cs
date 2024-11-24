namespace DesignPatterns.Decorator.ExampleImplementation;

public class BluePaintTeslaDecorator(ITeslaCar component) : TeslaDecorator(component)
{
    public override decimal GetPrice()
    {
        return base.GetPrice() + 1_000m;
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Blue paint";
    }
}