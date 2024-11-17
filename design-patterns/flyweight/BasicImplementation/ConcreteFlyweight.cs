namespace DesignPatterns.Flyweight.BasicImplementation;

public sealed class ConcreteFlyweight(string intrinsicState) : Flyweight
{
    private readonly string _intrinsicState = intrinsicState;

    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"Flyweight operation with intrinsic state '{_intrinsicState}' and extrinsic state '{extrinsicState}'");
    }
}