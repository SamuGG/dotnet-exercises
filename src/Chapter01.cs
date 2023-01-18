using System.Diagnostics.CodeAnalysis;

namespace FunctionalProgramming.Exercises.Chapter01;

public static class Solutions
{
    public static bool Negate<T>(this Func<T, bool> predicate, T obj)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return !predicate(obj);
    }

    [SuppressMessage("Design", "CA1002: Do not expose generic lists")]
    public static List<int> Quicksort(this List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        if (list.Count == 0)
            return list;

        var pivot = list.First();
        var lowerElements = list.Skip(1).Where(x => x <= pivot).ToList();
        var higherElements = list.Skip(1).Where(x => pivot < x).ToList().Quicksort();

        return lowerElements.Quicksort()
            .Append(pivot)
            .Concat(higherElements.Quicksort())
            .ToList();
    }

    [SuppressMessage("Design", "CA1002: Do not expose generic lists")]
    public static List<T> Quicksort<T>(this List<T> list, Comparison<T> comparison)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(comparison);

        if (list.Count == 0)
            return list;

        var pivot = list.First();
        var lowerElements = list.Skip(1).Where(x => comparison(x, pivot) <= 0).ToList();
        var higherElements = list.Skip(1).Where(x => 0 < comparison(x, pivot)).ToList();

        return lowerElements.Quicksort(comparison)
            .Append(pivot)
            .Concat(higherElements.Quicksort(comparison))
            .ToList();
    }

    public static T Using<TDisp, T>(Func<TDisp> disposableProvider, Func<TDisp, T> f) where TDisp : IDisposable
    {
        ArgumentNullException.ThrowIfNull(disposableProvider);
        ArgumentNullException.ThrowIfNull(f);
        
        using var disposable = disposableProvider();
        return f(disposable);
    }
}