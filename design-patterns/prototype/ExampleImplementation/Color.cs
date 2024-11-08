namespace DesignPatterns.Prototype.ExampleImplementation;

public sealed record Color(int Red, int Green, int Blue) : IPrototype<Color>
{
    public static Color LightGrey = new(217, 217, 217);

    public Color DeepClone()
    {
        return new Color(Red, Green, Blue);
    }

    public Color ShallowClone()
    {
        return this with { };
    }
};