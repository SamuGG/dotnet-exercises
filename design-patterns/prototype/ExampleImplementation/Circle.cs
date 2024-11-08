namespace DesignPatterns.Prototype.ExampleImplementation;

public record Circle(int radius, Color color) : IShape
{
    private readonly int _radius = radius;
    private readonly Color _color = color;

    public IShape DeepClone()
    {
        return new Circle(_radius, _color.DeepClone());
    }

    public IShape ShallowClone()
    {
        return this with { };
    }
}