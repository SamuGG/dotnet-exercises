using FunctionalProgramming.Exercises.Chapter08;
using F = LaYumba.Functional.F;

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
}