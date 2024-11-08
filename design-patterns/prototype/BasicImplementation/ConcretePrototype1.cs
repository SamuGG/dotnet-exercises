namespace DesignPatterns.Prototype.BasicImplementation;

public record ConcretePrototype1(int Width, int Height, ICollection<string> Layers) : Prototype<ConcretePrototype1>
{
    public ConcretePrototype1 DeepClone()
    {
        return new(Width, Height, [.. Layers]);
    }

    public ConcretePrototype1 ShallowClone()
    {
        return this with { };
    }
}