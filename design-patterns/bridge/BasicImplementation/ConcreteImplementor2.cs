namespace DesignPatterns.Bridge.BasicImplementation;

public class ConcreteImplementor2 : Implementor
{
    public void WriteLine()
    {
        Console.WriteLine($"Hello from {nameof(ConcreteImplementor2)}");
    }
}