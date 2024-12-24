namespace DesignPatterns.Visitor.BasicImplementation;

public sealed class ConcreteElement2 : Element
{
    public void Accept(Visitor visitor)
    {
        visitor.Visit(this);
    }

    public string Operation2()
    {
        return "Concrete element 2";
    }
}
