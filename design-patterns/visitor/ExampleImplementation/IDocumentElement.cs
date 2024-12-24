namespace DesignPatterns.Visitor.ExampleImplementation;

public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
}