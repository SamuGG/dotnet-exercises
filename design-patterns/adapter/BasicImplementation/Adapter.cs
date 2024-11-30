namespace DesignPatterns.Adapter.BasicImplementation;

public sealed class Adapter(Adaptee adaptee) : Target
{
    private readonly Adaptee _adaptee = adaptee;

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}