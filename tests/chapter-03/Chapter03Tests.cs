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
}