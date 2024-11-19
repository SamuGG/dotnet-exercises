namespace DesignPatterns.Composite.ExampleImplementation;

public class Course(string name, TimeSpan duration, decimal price) : LearningResource
{
    private readonly string _name = name;
    private readonly TimeSpan _duration = duration;
    private readonly decimal _price = price;

    public override string GetName()
    {
        return _name;
    }

    public override TimeSpan GetDuration()
    {
        return _duration;
    }

    public override decimal GetPrice()
    {
        return _price;
    }
}