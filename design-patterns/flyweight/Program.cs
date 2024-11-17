using DesignPatterns.Flyweight.BasicImplementation;
using DesignPatterns.Flyweight.ExampleImplementation;

FlyweightFactory flyweightFactory = new();
Client client = new(flyweightFactory);
client.Operation("Hello");
client.Operation("Hi");
client.Operation("World");

Console.WriteLine();

GlyphFactory glyphFactory = new();
DocumentEditor documentEditor = new(glyphFactory);
const string text = "Hello Flyweight!";
int x = 0;
int y = 0;

foreach (char character in text)
{
    documentEditor.InsertCharacter(character, "Arial", x, y, 12, "Black");
    x += 10;
}

string upperText = text.ToUpperInvariant();
y += 20;

foreach (char character in upperText)
{
    documentEditor.InsertCharacter(character, "Consolas", x, y, 14, "Grey");
    x += 12;
}

documentEditor.Render();