namespace DesignPatterns.Adapter.ExampleImplementation;

public sealed class LegacyRectangleAdapter(LegacyRectangle legacyRectangle) : IRectangle
{
    private readonly LegacyRectangle _legacyRectangle = legacyRectangle;

    public long GetArea()
    {
        return _legacyRectangle.CalculateArea();
    }

    public long GetPerimeter()
    {
        return _legacyRectangle.CalculatePerimeter();
    }

    public void Move(long dx, long dy)
    {
        _legacyRectangle.Shift(horizontal: Convert.ToInt32(dx), vertical: Convert.ToInt32(dy));
    }
}