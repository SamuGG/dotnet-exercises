namespace DesignPatterns.Prototype.BasicImplementation;

public interface Prototype<T>
{
    T ShallowClone();
    T DeepClone();
}