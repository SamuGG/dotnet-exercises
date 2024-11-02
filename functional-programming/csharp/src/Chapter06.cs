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

    [SuppressMessage("Design", "CA1034: Nested types should not be visible")]
    public sealed class Age : IEquatable<Age>
    {
        private readonly int _value;

        private Age(int value)
        {
            _value = value;
        }

        public static Option<Age> Of(int value) =>
            value >= 0 ? new Age(value) : F.None;

        public bool Equals(Age? other)
        {
            return other is not null
                && _value == other._value;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Age);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }
    }

    [SuppressMessage("CodeQuality", "IDE0052: Remove unread private member")]
    [SuppressMessage("Performance", "CA1823: Avoid unused private fields")]
    public static readonly Func<string, Option<Age>> ParseAge = s
        => ParseInt(s).Bind(Age.Of);

    internal static Either<string, int> ParseInt(this string s)
       => Int.Parse(s).ToEither(() => $"'{s}' is not a valid representation of an int");

    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static Option<RR> Bind<L, R, RR>(this Either<L, R> either, Func<R, Option<RR>> f)
        => either.Match(
            _ => F.None,
            r => f(r));

    [SuppressMessage("Design", "CA1031: Do not catch general exception types")]
    public static Exceptional<T> Try<T>(Func<T> f)
    {
        ArgumentNullException.ThrowIfNull(f);
        try
        {
            return f();
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    [SuppressMessage("Design", "CA1031: Do not catch general exception types")]
    public static Either<L, R> Try2<L, R>(Func<R> f, Func<Exception, L> left)
    {
        ArgumentNullException.ThrowIfNull(f);
        ArgumentNullException.ThrowIfNull(left);

        try
        {
            return F.Right(f());
        }
        catch (Exception ex)
        {
            return F.Left(left(ex));
        }
    }
}