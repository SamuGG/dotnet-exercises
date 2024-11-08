namespace DesignPatterns.Prototype.BasicImplementation;

public record ConcretePrototype2(int Radius, ICollection<string> Layers) : Prototype<ConcretePrototype2>
{
    public ConcretePrototype2 DeepClone()
    {
        return new(Radius, [.. Layers]);
    }

    public ConcretePrototype2 ShallowClone()
    {
        return this with { };
    }
}