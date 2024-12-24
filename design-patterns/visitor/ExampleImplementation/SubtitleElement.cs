namespace DesignPatterns.Visitor.ExampleImplementation;

public class SubtitleElement(string text) : IDocumentElement
{
    public string Text => text;

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}
