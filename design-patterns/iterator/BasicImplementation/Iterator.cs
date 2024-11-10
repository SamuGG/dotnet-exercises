namespace DesignPatterns.Iterator.BasicImplementation;

public interface Iterator<T>
{
    bool HasNext();
    T Next();
    void Reset();
}