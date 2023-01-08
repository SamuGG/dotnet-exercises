using FunctionalProgramming.Exercises.Chapter01;

namespace FunctionalProgramming.Exercises.Tests;

public class Chapter01Tests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PredicateIsNegated(bool predicateResult)
    {
        var predicate = new Func<object?, bool>(_ => predicateResult);
        bool actual = predicate.Negate(default);
        Assert.Equal(!predicateResult, actual);
    }
}