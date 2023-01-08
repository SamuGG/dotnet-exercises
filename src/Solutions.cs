namespace FunctionalProgramming.Exercises.Chapter01;

public static class Solutions
{
    public static bool Negate<T>(this Func<T, bool> predicate, T obj)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return !predicate(obj);
    }
}