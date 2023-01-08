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

    [Fact]
    public void QuicksortReturnsNewListSorted()
    {
        var list = new List<int> { 5, 2, 3, 8, 4, 7, 1, 6 };
        var actual = list.Quicksort();
        Assert.NotSame(actual, list);
        Assert.Equal(Enumerable.Range(1, 8), actual);
    }
}