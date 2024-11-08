namespace DesignPatterns.Bridge.BasicImplementation;

public class RefinedAbstraction2(Implementor implementor) : Abstraction(implementor)
{
    public override void UseImplementor()
    {
        Console.Write($"The time at {nameof(RefinedAbstraction2)} is: ");
        Console.WriteLine(DateTime.Now.ToString("u"));
        Implementor.WriteLine();
        Console.WriteLine();
    }
}