# Chapter 01 Exercises

## Exercise 1

Write a function that negates a given predicate: whenever the given predicate evaluates to _true_, the resulting function evaluates to _false_, and vice versa

## Exercise 2

Write a method that uses quicksort to sort a `List<int>` (return a new list, rather than sorting it in place)

## Exercise 3

Generalize the previous implementation to take a `List<T>`, and additionally a `Comparison<T>` delegate

## Exercise 4

In this chapter, you’ve seen a `Using` function that takes an `IDisposable` and a function of type `Func<TDisp, R>`. Write an overload of `Using` that takes a `Func<IDisposable>` as the first parameter, instead of the `IDisposable` (This can be used to avoid warnings raised by some code analysis tools about instantiating an `IDisposable` and not disposing it)
