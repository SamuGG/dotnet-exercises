# Chapter 04 Exercises

## Exercise 1

Implement `Map` for `ISet<T>` and `IDictionary<K, T>`

> Tip: start by writing down the signature in arrow notation

## Exercise 2

Implement `Map` for `Option` and `IEnumerable` in terms of `Bind` and `Return`

## Exercise 3

Use `Bind` and an Option-returning lookup function (such as the one we defined in chapter 3) to implement `GetWorkPermit` (shown below). Then enrich the implementation so that `GetWorkPermit` returns `None` if the work permit has expired

## Exercise 4

Use `Bind` to implement `AverageYearsWorkedAtTheCompany`, shown below (only employees who have left should be included)

```cs
Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId) => // your implementation here...

double AverageYearsWorkedAtTheCompany(List<Employee> employees) => // your implementation here...

public class Employee
{
    public string Id { get; set; }
    public Option<WorkPermit> WorkPermit { get; set; }
    public DateTime JoinedOn { get; }
    public Option<DateTime> LeftOn { get; }
}

public struct WorkPermit
{
    public string Number { get; set; }
    public DateTime Expiry { get; set; }
}
```
