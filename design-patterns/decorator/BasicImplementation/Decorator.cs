namespace DesignPatterns.Decorator.BasicImplementation;

public abstract class Decorator(Component component) : Component
{
    private readonly Component _component = component;

    public virtual void Operation()
    {
        _component.Operation();
    }
}