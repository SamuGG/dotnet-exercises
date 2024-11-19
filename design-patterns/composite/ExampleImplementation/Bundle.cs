
namespace DesignPatterns.Composite.ExampleImplementation;

public class Bundle(string name, double discount) : LearningResource
{
    private readonly string _name = name;
    private readonly double _discount = discount;
    private readonly List<LearningResource> _courses = [];

    public override TimeSpan GetDuration()
    {
        double totalSeconds = _courses.Sum(course => course.GetDuration().TotalSeconds);
        return TimeSpan.FromSeconds(totalSeconds);
    }

    public override string GetName()
    {
        return _name;
    }

    public override decimal GetPrice()
    {
        decimal totalPriceWithoutDiscount = _courses.Sum(course => course.GetPrice());
        decimal discounter = (decimal)(1.0 - _discount / 100.0);

        return totalPriceWithoutDiscount * discounter;
    }

    public override void Add(LearningResource learningResource)
    {
        _courses.Add(learningResource);
    }

    public override void Remove(LearningResource learningResource)
    {
        _courses.Remove(learningResource);
    }

    public override LearningResource? GetLearningResouce(string name)
    {
        return _courses.SingleOrDefault(course => course.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}