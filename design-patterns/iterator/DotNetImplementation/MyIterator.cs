using System.Collections;

namespace DesignPatterns.Iterator.DotNetImplementation;

public class MyIterator<T>(MyCollection<T> aggregate) : IEnumerator<T>
{
    private readonly MyCollection<T> _aggregate = aggregate;
    private int _currentIndex = -1;
    private T? _current = default;

    public T Current => _current;
    object? IEnumerator.Current => Current;

    public bool HasNext()
    {
        return _currentIndex < _aggregate.Count - 1;
    }

    public bool MoveNext()
    {
        if (!HasNext())
            return false;

        _current = _aggregate[++_currentIndex];
        return true;
    }

    public void Reset()
    {
        _currentIndex = -1;
        _current = default;
    }

    public void Dispose()
    {
    }
}