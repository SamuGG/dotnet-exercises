namespace DesignPatterns.Bridge.BasicImplementation;

public class RefinedAbstraction1(Implementor implementor) : Abstraction(implementor)
{
    public override void UseImplementor()
    {
        Console.WriteLine($"Invoking implementor method from {nameof(RefinedAbstraction1)}");
        Implementor.WriteLine();
        Console.WriteLine($"Implementor method invoked from {nameof(RefinedAbstraction1)}");
        Console.WriteLine();
    }
}