using System.Collections;

namespace DesignPatterns.Iterator.DotNetImplementation;

public class MyCollection<T> : IEnumerable<T>
{
    private readonly List<T> _items = [];

    public int Count => _items.Count;

    public T this[int index] => _items[index];

    public void Add(T value)
    {
        _items.Add(value);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyIterator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}