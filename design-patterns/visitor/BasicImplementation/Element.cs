namespace DesignPatterns.Visitor.BasicImplementation;

public interface Element
{
    void Accept(Visitor visitor);
}