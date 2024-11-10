namespace DesignPatterns.Iterator.BasicImplementation;

public interface Aggregate<T>
{
    Iterator<T> CreateIterator();
    void Add(T value);
}