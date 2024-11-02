using FunctionalProgramming.Exercises.Chapter08;
using F = LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace FunctionalProgramming.Exercises.Tests.Chapter08;

public class SolutionsTests
{
    [Fact]
    public void ApplyEitherReturnsLeftWhenNoFunction()
    {
        const string stateWhenNofunction = "No function";
        LaYumba.Functional.Either<string, Func<int, double>> noFunction = F.Left(stateWhenNofunction);
        LaYumba.Functional.Either<string, int> valueToApply = F.Right(5);

        LaYumba.Functional.Either<string, double> actual = noFunction.Apply(valueToApply);

        actual.Match(
            left => Assert.Equal(stateWhenNofunction, left),
            right => Assert.Fail("Expected an Either with left state but found right state"));
    }

    [Fact]
    public void ApplyEitherReturnsLeftWhenNoValue()
    {
        const string stateWhenNoValue = "No value";
        LaYumba.Functional.Either<string, Func<int, double>> someFunction = F.Right<Func<int, double>>(i => i / 3);
        LaYumba.Functional.Either<string, int> noValue = F.Left(stateWhenNoValue);

        LaYumba.Functional.Either<string, double> actual = someFunction.Apply(noValue);

        actual.Match(
            left => Assert.Equal(stateWhenNoValue, left),
            right => Assert.Fail("Expected an Either with left state but found right state"));
    }

    [Fact]
    public void ApplyEitherReturnsRightProvidedFunctionAndValue()
    {
        LaYumba.Functional.Either<string, Func<int, double>> someFunction = F.Right<Func<int, double>>(i => i / 3);
        LaYumba.Functional.Either<string, int> someValue = F.Right(27);

        LaYumba.Functional.Either<string, double> actual = someFunction.Apply(someValue);

        actual.Match(
            left => Assert.Fail("Expected an Either with right state but found left state"),
            right => Assert.Equal(9, right));
    }

    [Fact]
    public void ApplyExceptionalReturnsLeftWhenNoFunction()
    {
        LaYumba.Functional.Exceptional<Func<int, double>> throwingFunction = new NotImplementedException();
        LaYumba.Functional.Exceptional<int> valueToApply = 25;

        LaYumba.Functional.Exceptional<double> actual = throwingFunction.Apply(valueToApply);

        actual.Match(
            ex => Assert.IsType<NotImplementedException>(ex),
            value => Assert.Fail("Expected an exception but found some value instead"));
    }

    [Fact]
    public void ApplyExceptionalReturnsLeftWhenNoValue()
    {
        LaYumba.Functional.Exceptional<Func<int, double>> someFunction = new Func<int, double>(i => i / 3);
        LaYumba.Functional.Exceptional<int> exceptionValue = new NotImplementedException();

        LaYumba.Functional.Exceptional<double> actual = someFunction.Apply(exceptionValue);

        actual.Match(
            ex => Assert.IsType<NotImplementedException>(ex),
            value => Assert.Fail("Expected an exception but found some value instead"));
    }

    [Fact]
    public void ApplyExceptionalReturnsRightProvidedFunctionAndValue()
    {
        LaYumba.Functional.Exceptional<Func<int, double>> someFunction = new Func<int, double>(i => i / 3);
        LaYumba.Functional.Exceptional<int> someValue = 30;

        LaYumba.Functional.Exceptional<double> actual = someFunction.Apply(someValue);

        actual.Match(
            ex => Assert.Fail("Expected some value but found an exception instead"),
            right => Assert.Equal(10, right));
    }

    [Fact]
    public void QuerySyntaxWorksOnLeftEither()
    {
        const string leftState = "Invalid state";
        LaYumba.Functional.Either<string, int> eitherLeft = F.Left(leftState);

        var actual =
            from e in eitherLeft
            select e + 5;

        actual.Match(
            l => Assert.Equal(leftState, l),
            r => Assert.Fail("Expected Either with left state but found right state instead"));
    }

    [Fact]
    public void QuerySyntaxWorksOnRightEither()
    {
        LaYumba.Functional.Either<string, int> eitherRight = F.Right(13);

        var actual =
            from e in eitherRight
            select e + 5;

        actual.Match(
            l => Assert.Fail("Expected Either with right state but found left state instead"),
            r => Assert.Equal(18, r));
    }

    [Fact]
    public void QuerySyntaxWorksOnManyLeftEithers()
    {
        const string leftState = "Invalid state";
        LaYumba.Functional.Either<string, int> eitherLeft = F.Left(leftState);
        LaYumba.Functional.Either<string, int> eitherRight = F.Right(64);

        var actual =
            from l in eitherLeft
            from r in eitherRight
            select l - r;

        actual.Match(
            l => Assert.Equal(leftState, l),
            r => Assert.Fail("Expected some Either with left state"));
    }

    [Fact]
    public void QuerySyntaxWorksOnManyRightEithers()
    {
        LaYumba.Functional.Either<string, int> num1 = F.Right(13);
        LaYumba.Functional.Either<string, int> num2 = F.Right(51);

        var actual =
            from a in num1
            from b in num2
            select a + b;

        actual.Match(
            l => Assert.Fail("Expected all Eithers with right state"),
            r => Assert.Equal(64, r));
    }

    [Fact]
    public void QuerySyntaxWorksWithExceptions()
    {
        LaYumba.Functional.Exceptional<int> exceptional = new NotImplementedException();

        var actual =
            from e in exceptional
            select e + 5;

        actual.Match(
            ex => Assert.IsType<NotImplementedException>(ex),
            value => Assert.Fail("Expected an exception but found some value instead"));
    }

    [Fact]
    public void QuerySyntaxWorksWithoutExceptions()
    {
        LaYumba.Functional.Exceptional<int> exceptional = 26;

        var actual =
            from e in exceptional
            select e + 4;

        actual.Match(
            ex => Assert.Fail("Expected some value but found an exception instead"),
            value => Assert.Equal(30, value));
    }

    [Fact]
    public void QuerySyntaxWorksOnManyExceptionals()
    {
        LaYumba.Functional.Exceptional<int> failed = new NotImplementedException();
        LaYumba.Functional.Exceptional<int> successful = 11;

        var actual =
            from a in failed
            from b in successful
            select a - b;

        actual.Match(
            ex => Assert.IsType<NotImplementedException>(ex),
            value => Assert.Fail("Expected some exception but found some value instead"));
    }

    [Fact]
    public void QuerySyntaxWorksOnManySuccessExceptionals()
    {
        LaYumba.Functional.Exceptional<int> num1 = 32;
        LaYumba.Functional.Exceptional<int> num2 = 32;

        var actual =
            from a in num1
            from b in num2
            select a + b;

        actual.Match(
            ex => Assert.Fail("Expected some value but found some exception instead"),
            value => Assert.Equal(64, value));
    }

    [Fact]
    public void PrepareFavouriteDishWithLinq()
    {
        LaYumba.Functional.Either<string, Unit> WakeUpEarly() => F.Right(Unit.Create());
        LaYumba.Functional.Either<string, Ingredients> ShopForIngredients() => F.Right(new Ingredients());
        LaYumba.Functional.Either<string, Food> CookRecipe(Ingredients ingredients) => F.Right(new Food());

        LaYumba.Functional.Either<string, Food> cookFood =
            from _ in WakeUpEarly()
            from ingredients in ShopForIngredients()
            from dish in CookRecipe(ingredients)
            select dish;

        cookFood.Match(
            reason => Assert.Fail(reason),
            _ => Assert.True(true));
    }

    private struct Food { }
    private struct Ingredients { }
}