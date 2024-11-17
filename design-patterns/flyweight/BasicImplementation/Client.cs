namespace DesignPatterns.Flyweight.BasicImplementation;

internal sealed class Client(FlyweightFactory flyweightFactory)
{
    private readonly FlyweightFactory _flyweightFactory = flyweightFactory;

    public void Operation(string extrinsicState)
    {
        if (string.IsNullOrWhiteSpace(extrinsicState))
            return;

        string key1 = extrinsicState[0].ToString();
        string key2 = extrinsicState[0].ToString();

        Flyweight? flyweight1 = _flyweightFactory.GetFlyweight(key1);
        Flyweight? flyweight2 = _flyweightFactory.GetFlyweight(key2);

        if (flyweight1 is { })
            flyweight1.Operation(extrinsicState);

        if (flyweight2 is { })
            flyweight2.Operation(extrinsicState);
    }
}