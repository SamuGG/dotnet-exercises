namespace DesignPatterns.Prototype.ExampleImplementation;

public record Rectangle(int width, int height, Color color) : IShape
{
    private readonly int _width = width;
    private readonly int _height = height;
    private readonly Color _color = color;

    public IShape DeepClone()
    {
        return new Rectangle(_width, _height, _color.DeepClone());
    }

    public IShape ShallowClone()
    {
        return this with { };
    }
}