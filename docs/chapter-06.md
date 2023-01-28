# Chapter 06 Exercises

## Exercise 1

Write a `ToOption` extension method to convert an `Either` into an `Option`; the left value is thrown away if present.

Then write a `ToEither` method to convert an `Option` into an `Either`, with a suitable parameter that can be invoked to obtain the appropriate left value if the `Option` is `None`.

Tip: start by writing the function signatures in arrow notation.

## Exercise 2

Take a workflow where two or more functions that return an `Option` are chained using `Bind`. Then change the first of the functions to return an `Either`.

This should cause compilation to fail. `Either` can be converted into an `Option`, as you saw in the previous exercise, so write extension overloads for `Bind` so that functions returning `Either` and `Option` can be chained with `Bind`, yielding an `Option`.

## Exercise 3

Write a function with signature

```sh
TryRun : (() -> T) -> Exceptional<T>
```

that runs the given function in a try/catch, returning an appropriately populated `Exceptional`.

## Exercise 4

Write a function with signature

```sh
Safely : ((() -> R), (Exception -> L)) -> Either<L, R>
```

that runs the given function in a try/catch, returning an appropriately populated `Either`.
