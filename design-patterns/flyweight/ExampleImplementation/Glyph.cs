namespace DesignPatterns.Flyweight.ExampleImplementation;

public sealed class Glyph(char character, string fontFamily) : IGlyph
{
    private readonly char _character = character;
    private readonly string _fontFamily = fontFamily;

    public void Render(int x, int y, int fontSize, string color)
    {
        Console.WriteLine($"Rendering glyph '{_character}' at ({x}, {y}) with font family '{_fontFamily}', size {fontSize} and color '{color}'");
    }
}