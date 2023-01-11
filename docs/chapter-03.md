# Chapter 03 Exercises

## Exercise 1

Write a generic function that takes a string and parses it as a value of an _enum_. It should be usable as follows:

```cs
Enum.Parse<DayOfWeek>("Friday")  // => Some(DayOfWeek.Friday)
Enum.Parse<DayOfWeek>("Freeday") // => None 
```

## Exercise 2

Write a Lookup function that will take an `IEnumerable` and a predicate, and return the first element in the `IEnumerable` that matches the predicate, or `None` if no matching element is found. Write its signature in arrow notation:

```cs
bool isOdd(int i) => i % 2 == 1;
new List<int>().Lookup(isOdd)     // => None
new List<int> { 1 }.Lookup(isOdd) // => Some(1)
```

## Exercise 3

Write a type `Email` that wraps an underlying string, enforcing that it’s in a valid format. Ensure that you include the following:

- A smart constructor
- Implicit conversion to string, so that it can easily be used with the typical API for sending emails

## Exercise 4

Write implementations for the methods in the following `AppConfig` class.

(For both methods, a reasonable one-line method body is possible. Assume the settings are of type string, numeric, or date)

Can this implementation help you to test code that relies on settings in a `.config` file?

```cs
using System.Collections.Specialized;
using System.Configuration;
using LaYumba.Functional;

public class AppConfig
{
    NameValueCollection source;
    
    public AppConfig() : this(ConfigurationManager.AppSettings) { }
    
    public AppConfig(NameValueCollection source)
    {
        this.source = source;
    }

    public Option<T> Get<T>(string name)
    {
        // your implementation here...
    }
    
    public T Get<T>(string name, T defaultValue)
    {
        // your implementation here...
    }
}
```

<!-- cspell:ignore Freeday -->
