namespace DesignPatterns.Adapter.ExampleImplementation;

public sealed class LegacyRectangle(int left, int top, int right, int bottom)
{
    private int Height => bottom - top;
    private int Width => right - left;

    public int CalculateArea()
    {
        return Height * Width;
    }

    public int CalculatePerimeter()
    {
        return 2 * (Height + Width);
    }

    public void Shift(int horizontal, int vertical)
    {
        top += vertical;
        bottom += vertical;

        left += horizontal;
        right += horizontal;
    }
}