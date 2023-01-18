using FunctionalProgramming.Exercises.Chapter04;

namespace FunctionalProgramming.Exercises.Tests.Chapter04;

public class SolutionsTests
{
    [Fact]
    public void MapSetOfIntsToSetOfMultiplesOfThree()
    {
        var setOfInts = new HashSet<int>(new[] { 1, 2, 3, 4, 5 });
        var multiplyByThree = new Func<int, int>(i => i * 3);

        var actual = setOfInts.Map(multiplyByThree);

        Assert.NotSame(actual, setOfInts);
        var expected = new HashSet<int>(new[] { 3, 6, 9, 12, 15 });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MapDictionaryOfIntsToDictionaryOfMultiplesOfFive()
    {
        var dictionaryOfInts = new Dictionary<int, int> {
            {1, 2},
            {2, 4},
            {3, 6},
            {4, 8},
            {5, 10}
        };
        var multiplyByFive = new Func<int, int>(i => i * 5);

        var actual = dictionaryOfInts.Map(multiplyByFive);

        Assert.NotSame(actual, dictionaryOfInts);
        var expected = new Dictionary<int, int> {
            {1, 10},
            {2, 20},
            {3, 30},
            {4, 40},
            {5, 50}
        };
        Assert.Equal(expected, actual);
    }
}