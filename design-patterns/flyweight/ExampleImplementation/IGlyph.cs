namespace DesignPatterns.Flyweight.ExampleImplementation;

public interface IGlyph
{
    void Render(int x, int y, int fontSize, string color);
}