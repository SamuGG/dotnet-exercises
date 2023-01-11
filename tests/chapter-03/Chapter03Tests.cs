using FunctionalProgramming.Exercises.Chapter03;
using LaYumba.Functional;

namespace FunctionalProgramming.Exercises.Tests;

public class Chapter03Tests
{
    public static TheoryData<string, Option<DayOfWeek>> ParseTestData => new()
    {
        { "Friday", F.Some(DayOfWeek.Friday) },
        { "Friturday", F.None }
    };

    [Theory]
    [MemberData(nameof(ParseTestData))]
    public void ParseStringReturnsOption(string value, Option<DayOfWeek> possibleDay)
    {
        var actual = value.Parse2<DayOfWeek>();
        Assert.Equal(possibleDay, actual);
    }

    public static TheoryData<IEnumerable<int>, int, Option<int>> LookupTestData => new()
    {
        { new List<int> { 1, 2, 3 }, 4, F.None },
        { new List<int> { 1, 2, 3 }, 2, F.Some(2) }
    };

    [Theory]
    [MemberData(nameof(LookupTestData))]
    public void LookupReturnsOption(IEnumerable<int> haystack, int needle, Option<int> expected)
    {
        var actual = haystack.Lookup(x => x == needle);
        Assert.Equal(expected, actual);
    }
}