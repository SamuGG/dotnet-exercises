namespace DesignPatterns.Bridge.BasicImplementation;

public class ConcreteImplementor1 : Implementor
{
    public void WriteLine()
    {
        Console.WriteLine($"Hello from {nameof(ConcreteImplementor1)}");
    }
}