using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace FunctionalProgramming.Exercises.Chapter03;

public static class Solutions
{
    public static Option<T> Parse2<T>(this string value) where T : struct
    {
        return System.Enum.TryParse(value, out T converted) ? Some(converted) : None;
    }

    public static Option<T> Lookup<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(enumerable);
        ArgumentNullException.ThrowIfNull(predicate);

        foreach (T element in enumerable)
            if (predicate(element))
                return Some(element);

        return None;
    }
}