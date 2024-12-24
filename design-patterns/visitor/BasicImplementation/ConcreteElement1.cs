namespace DesignPatterns.Visitor.BasicImplementation;

public sealed class ConcreteElement1 : Element
{
    public void Accept(Visitor visitor)
    {
        visitor.Visit(this);
    }

    public string Operation1()
    {
        return "Concrete element 1";
    }
}
