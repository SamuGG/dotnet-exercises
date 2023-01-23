using FunctionalProgramming.Exercises.Chapter01;

namespace FunctionalProgramming.Exercises.Tests.Chapter01;

public class SolutionsTests
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

    [Fact]
    public void QuicksortWithComparisonReturnsNewListSorted()
    {
        var list = new List<double> { 1, -2, -1, 4, 0, 3, -3, 2 };
        var actual = list.Quicksort(Comparer<double>.Default.Compare);
        Assert.NotSame(actual, list);
        Assert.Equal(Enumerable.Range(-3, 8).Select(x => (double)x), actual);
    }

    [Fact]
    public void UsingDisposableWrapsIt()
    {
        var disposableProvider = new Func<CharEnumerator>(() => "Hello".GetEnumerator());
        var getFirstRepeatedChar = new Func<CharEnumerator, char>(d =>
        {
            char lastChar = '\0';
            while (d.MoveNext())
            {
                if (d.Current == lastChar)
                    return d.Current;
                lastChar = d.Current;
            }
            return lastChar;
        });

        char repeatedChar = Solutions.Using(disposableProvider, getFirstRepeatedChar);

        Assert.Equal('l', repeatedChar);
    }
}