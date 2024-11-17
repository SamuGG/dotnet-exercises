namespace DesignPatterns.Flyweight.BasicImplementation;

public sealed class FlyweightFactory
{
    private readonly Dictionary<string, Flyweight> _flyweights = [];

    public Flyweight? GetFlyweight(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return null;

        if (!_flyweights.TryGetValue(key, out Flyweight? flyweight))
        {
            flyweight = new ConcreteFlyweight(intrinsicState: key);
            _flyweights[key] = flyweight;
        }

        return flyweight;
    }
}