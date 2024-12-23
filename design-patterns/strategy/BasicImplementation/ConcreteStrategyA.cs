namespace DesignPatterns.Strategy.BasicImplementation;

public class ConcreteStrategyA : Strategy
{
    public void Execute()
    {
        Console.WriteLine("Executing strategy A");
    }
}