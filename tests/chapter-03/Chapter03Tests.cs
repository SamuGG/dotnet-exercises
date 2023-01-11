using System.Collections.Specialized;
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
    public void ParseStringReturnsPossibleEnum(string value, Option<DayOfWeek> possibleDay)
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
    public void LookupReturnsPossibleValue(IEnumerable<int> haystack, int needle, Option<int> expected)
    {
        var actual = haystack.Lookup(x => x == needle);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<NameValueCollection, string, Option<int>> ConfigOptionalTestData => new()
    {
        { new NameValueCollection { ["key4"] = "-123" }, "key4", F.Some(-123) },
        { new NameValueCollection(), "key4", F.None }
    };

    [Theory]
    [MemberData(nameof(ConfigOptionalTestData))]
    public void GetPossibleMappedValue(NameValueCollection map, string key, Option<int> expected)
    {
        var sut = new AppConfig(map);
        var actual = sut.Get<int>(key);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<NameValueCollection, string, int, int> ConfigStronglyTypedTestData => new()
    {
        { new NameValueCollection { ["key5"] = "880" }, "key5", 5, 880 },
        { new NameValueCollection(), "key5", 71, 71 }
    };

    [Theory]
    [MemberData(nameof(ConfigStronglyTypedTestData))]
    public void GetStronglyTypedMappedValue(NameValueCollection map, string key, int defaultValue, int expected)
    {
        var sut = new AppConfig(map);
        int actual = sut.Get(key, defaultValue);
        Assert.Equal(expected, actual);
    }
}