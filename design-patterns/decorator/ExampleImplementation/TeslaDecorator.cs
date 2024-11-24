namespace DesignPatterns.Decorator.ExampleImplementation;

public abstract class TeslaDecorator(ITeslaCar car) : ITeslaCar
{
    private readonly ITeslaCar _car = car;

    public virtual string GetDescription()
    {
        return _car.GetDescription();
    }

    public virtual decimal GetPrice()
    {
        return _car.GetPrice();
    }

    public virtual double GetRangeInKm()
    {
        return _car.GetRangeInKm();
    }
}