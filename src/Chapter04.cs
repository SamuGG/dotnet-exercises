using System.Diagnostics.CodeAnalysis;
using LaYumba.Functional;

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

    public static Option<TOut> Map<TIn, TOut>(this Option<TIn> o, Func<TIn, TOut> f)
    {
        return o.Bind(x => F.Some(f(x)));
    }

    public static IEnumerable<TOut> Map<TIn, TOut>(this IEnumerable<TIn> e, Func<TIn, TOut> f)
    {
        return e.Bind(x => new[] { f(x) });
    }

    public static Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId)
    {
        return people.Lookup(employeeId).Bind(e => e.WorkPermit);
    }

    static Func<WorkPermit, bool> HasExpired =>
        permit =>
            permit.Expiry < DateTime.Now.Date;

    public static Option<WorkPermit> GetValidWorkPermit(Dictionary<string, Employee> people, string employeeId)
    {
        return people.Lookup(employeeId).Bind(e => e.WorkPermit).Where(HasExpired.Negate());
        // return people.Lookup(employeeId).Bind(e => e.WorkPermit).Match(
        //     () => F.None,
        //     w => HasExpired(w) ? F.None : F.Some(w)
        // );
    }
}

public class Employee
{
    public string Id { get; set; } = string.Empty;
    public Option<WorkPermit> WorkPermit { get; set; }
    public DateTime JoinedOn { get; }
    public Option<DateTime> LeftOn { get; }
}

[SuppressMessage("Performance", "CA1815: Override equals and operator equals on value types")]
public struct WorkPermit
{
    public string Number { get; set; }
    public DateTime Expiry { get; set; }
}