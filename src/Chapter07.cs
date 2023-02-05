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

    public enum NumberType
    {
        Home,
        Mobile
    }

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
}