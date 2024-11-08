namespace DesignPatterns.Bridge.BasicImplementation;

public abstract class Abstraction(Implementor implementor)
{
    public Implementor Implementor { get; init; } = implementor;

    public abstract void UseImplementor();
}