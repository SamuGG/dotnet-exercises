namespace DesignPatterns.Decorator.BasicImplementation;

public class ConcreteDecorator1(Component component) : Decorator(component)
{
    public override void Operation()
    {
        Console.WriteLine($"Pre-operation from {nameof(ConcreteDecorator1)}");
        base.Operation();
        Console.WriteLine($"Post-operation from {nameof(ConcreteDecorator1)}");
    }
}