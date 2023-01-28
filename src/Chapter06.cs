using System.Diagnostics.CodeAnalysis;
using LaYumba.Functional;

namespace FunctionalProgramming.Exercises.Chapter06;

public static class Solutions
{
    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Option<R> ToOption<L, R>(this Either<L, R> either)
    {
        return either.Match(
            _ => F.None,
            r => F.Some(r));
    }

    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Either<L, R> ToEither<L, R>(this Option<R> option, Func<L> left)
    {
        return option.Match<Either<L, R>>(
            () => left(),
            r => r);
    }
}