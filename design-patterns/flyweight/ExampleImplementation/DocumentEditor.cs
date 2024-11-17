namespace DesignPatterns.Flyweight.ExampleImplementation;

internal sealed class DocumentEditor(GlyphFactory glyphFactory)
{
    private readonly GlyphFactory _glyphFactory = glyphFactory;
    private readonly List<(IGlyph Glyph, int X, int Y, int Size, string Color)> _characters = [];

    public void InsertCharacter(char character, string fontFamily, int x, int y, int size, string color)
    {
        IGlyph? glyph = _glyphFactory.GetGlyph(character, fontFamily);

        if (glyph is { })
        {
            Console.WriteLine($"Inserting character '{character} at ({x}, {y})");
            _characters.Add((glyph, x, y, size, color));
        }
    }

    public void Render()
    {
        Console.WriteLine("Rendering document:");

        foreach (var character in _characters)
            character.Glyph.Render(character.X, character.Y, character.Size, character.Color);
    }
}