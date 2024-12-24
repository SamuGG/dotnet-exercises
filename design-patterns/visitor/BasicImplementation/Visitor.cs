namespace DesignPatterns.Visitor.BasicImplementation;

public interface Visitor
{
    void Visit(ConcreteElement1 element1);
    void Visit(ConcreteElement2 element2);
}