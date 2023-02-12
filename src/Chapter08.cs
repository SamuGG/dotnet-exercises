using System.Diagnostics.CodeAnalysis;
using LaYumba.Functional;

namespace FunctionalProgramming.Exercises.Chapter08;

public static class Solutions
{
    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Either<L, R> Apply<T, L, R>(this Either<L, Func<T, R>> f, Either<L, T> t)
        => f.Match(
            leftF => F.Left(leftF),
            rightF => t.Match<Either<L, R>>(
                leftT => F.Left(leftT),
                rightT => F.Right(rightF(rightT))));

    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Exceptional<R> Apply<T, R>(this Exceptional<Func<T, R>> f, Exceptional<T> t)
        => f.Match(
            exceptionF => exceptionF,
            successF => t.Match<Exceptional<R>>(
                exceptionT => exceptionT,
                successT => successF(successT)));

    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Either<L, R> Select<L, T, R>(this Either<L, T> either, Func<T, R> f)
       => either.Map(f);
}