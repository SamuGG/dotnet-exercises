using System.Diagnostics.CodeAnalysis;
using LaYumba.Functional;

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

    [SuppressMessage("Design", "CA1034: Nested types should not be visible")]
    public class PhoneNumber
    {
        public NumberType Type { get; }
        public CountryCode Code { get; }
        public string Number { get; }

        public PhoneNumber(NumberType type, CountryCode code, string number)
        {
            Type = type;
            Code = code;
            Number = number;
        }
    }

    public enum NumberType { Home, Mobile }

    [SuppressMessage("Design", "CA1034: Nested types should not be visible")]
    [SuppressMessage("Usage", "CA2225: Operator overloads have named alternates")]
    public sealed class CountryCode
    {
        public string Value { get; }

        public CountryCode(string value) => Value = value;

        public override string ToString() => Value;

        public static implicit operator CountryCode(string value) => new(value);
        public static implicit operator string([NotNull] CountryCode code) => code.Value;
    }

    // Factory: (NumberType, CountryCode, string) -> PhoneNumber
    public static Func<CountryCode, NumberType, string, PhoneNumber> PhoneNumberFactory =>
        (code, type, number) => new(type, code, number);

    public static Func<NumberType, string, PhoneNumber> UkNumberFactory =>
        PhoneNumberFactory.Apply((CountryCode)"UK");

    public static Func<string, PhoneNumber> MobileUkNumberFactory =>
        UkNumberFactory.Apply(NumberType.Mobile);


    public enum LogLevel { Debug, Info, Error }

    public delegate void Log(LogLevel level, string message);

    public static void Debug(this Log log, string message)
    {
        ArgumentNullException.ThrowIfNull(log);
        log(LogLevel.Debug, message);
    }

    public static void Info(this Log log, string message)
    {
        ArgumentNullException.ThrowIfNull(log);
        log(LogLevel.Info, message);
    }

    public static void Error(this Log log, string message)
    {
        ArgumentNullException.ThrowIfNull(log);
        log(LogLevel.Error, message);
    }

    public static void ConsumeLog(Log log) =>
        log.Info("Info message to log");

    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static IEnumerable<R> MapInTermsOfAggregate<T, R>(this IEnumerable<T> collection, Func<T, R> f) =>
        collection.Aggregate(new List<R>(), (l, t) =>
        {
            l.Add(f(t));
            return l;
        });

    public static IEnumerable<T> WhereInTermsOfAggregate<T>(this IEnumerable<T> collection, Func<T, bool> f) =>
        collection.Aggregate(new List<T>(), (l, t) =>
        {
            if (f(t)) l.Add(t);
            return l;
        });

    [SuppressMessage("Naming", "CA1715: Identifiers should have correct prefix")]
    public static IEnumerable<IEnumerable<R>> BindInTermsOfAggregate<T, R>(this IEnumerable<T> collection, Func<T, IEnumerable<R>> f) =>
        collection.Aggregate(new List<IEnumerable<R>>(), (l, t) =>
        {
            l.Add(f(t));
            return l;
        });
}