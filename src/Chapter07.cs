using System.Diagnostics.CodeAnalysis;

namespace FunctionalProgramming.Exercises.Chapter07;

public static class Solutions
{
    public static Func<int, int, int> Remainder =>
        (int a, int b) => a % b;

    // ApplyR: (((T1, T2) -> R), T2) -> (T1 -> R)
    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Func<T1, R> ApplyR<T1, T2, R>(this Func<T1, T2, R> f, T2 t2) =>
        t1 => f(t1, t2);

    // ApplyR: (((T1, T2, T3) -> R), T3) -> ((T1, T2) -> R)
    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Func<T1, T2, R> ApplyR<T1, T2, T3, R>(this Func<T1, T2, T3, R> f, T3 t3) =>
        (t1, t2) => f(t1, t2, t3);
}