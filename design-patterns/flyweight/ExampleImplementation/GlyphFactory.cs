namespace DesignPatterns.Flyweight.ExampleImplementation;

public sealed class GlyphFactory
{
    private readonly Dictionary<(char, string), IGlyph> _glyphs = [];

    public IGlyph? GetGlyph(char character, string fontFamiliy)
    {
        var key = (character, fontFamiliy);
        if (!_glyphs.TryGetValue(key, out IGlyph? glyph))
        {
            Console.WriteLine($"Creating new glyph for '{character}' font '{fontFamiliy}'");
            glyph = new Glyph(character, fontFamiliy);
            _glyphs[key] = glyph;
        }

        return glyph;
    }
}