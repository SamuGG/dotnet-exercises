namespace FunctionalProgramming.Exercises.Chapter04;

public static class Solutions
{
    public static ISet<TOut> Map<TIn, TOut>(this ISet<TIn> set, Func<TIn, TOut> f)
    {
        return set.Select(x => f(x)).ToHashSet();
    }

    public static IDictionary<TKey, TResult> Map<TKey, TValue, TResult>(this IDictionary<TKey, TValue> d, Func<TValue, TResult> f) where TKey : notnull
    {
        return new Dictionary<TKey, TResult>(d.Select(pair => KeyValuePair.Create(pair.Key, f(pair.Value))));
    }
}