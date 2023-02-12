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
}