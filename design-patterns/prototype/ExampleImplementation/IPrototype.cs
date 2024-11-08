namespace DesignPatterns.Prototype.ExampleImplementation;

public interface IPrototype<T>
{
    T ShallowClone();
    T DeepClone();
}