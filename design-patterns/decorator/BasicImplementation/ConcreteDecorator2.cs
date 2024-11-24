namespace DesignPatterns.Decorator.BasicImplementation;

public class ConcreteDecorator2(Component component) : Decorator(component)
{
    public override void Operation()
    {
        Console.WriteLine($"Pre-operation from {nameof(ConcreteDecorator2)}");
        base.Operation();
        Console.WriteLine($"Post-operation from {nameof(ConcreteDecorator2)}");
    }
}