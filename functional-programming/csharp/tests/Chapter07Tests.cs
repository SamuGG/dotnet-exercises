using FunctionalProgramming.Exercises.Chapter07;
using Xunit.Abstractions;

namespace FunctionalProgramming.Exercises.Tests.Chapter07;

public class SolutionsTests
{
    private readonly ITestOutputHelper _testOutput;

    public SolutionsTests(ITestOutputHelper testOutput)
    {
        _testOutput = testOutput;
    }

    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(10, 3, 1)]
    [InlineData(-10, 3, -1)]
    public void RemainderOfDivision(int a, int b, int expected)
    {
        int actual = Solutions.Remainder(a, b);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ApplyRightmostParameterToBinaryFunction()
    {
        var binaryFunc = new Func<string, string, string>((a, b) =>
            string.Join(':', a, b));

        var unaryFunc = binaryFunc.ApplyR("right");

        string actual = unaryFunc("left");

        Assert.Equal("left:right", actual);
    }

    [Theory]
    [InlineData(-7, -2)]
    [InlineData(10, 0)]
    [InlineData(3, 3)]
    public void DivideIntegerByFive(int divisor, int expectedRemainder)
    {
        var divideByFive = Solutions.Remainder
            .ApplyR(5);

        int actualRemainder = divideByFive(divisor);

        Assert.Equal(expectedRemainder, actualRemainder);
    }

    [Fact]
    public void ApplyRightmostParameterToTernaryFunction()
    {
        var binaryFunc = new Func<string, string, string, string>((a, b, c) =>
            string.Join(':', a, b, c));

        var unaryFunc = binaryFunc.ApplyR("right");

        string actual = unaryFunc("left", "middle");

        Assert.Equal("left:middle:right", actual);
    }

    [Theory]
    [InlineData(Solutions.NumberType.Home, "0102 123 4567")]
    public void CreateUkPhoneNumber(Solutions.NumberType numberType, string number)
    {
        var actual = Solutions.UkNumberFactory(numberType, number);

        Assert.Equal("UK", actual.Code);
    }

    [Theory]
    [InlineData("0720 876 5432")]
    public void CreateUkMobilePhoneNumber(string number)
    {
        var actual = Solutions.MobileUkNumberFactory(number);

        Assert.Equal("UK", actual.Code);
        Assert.Equal(Solutions.NumberType.Mobile, actual.Type);
    }

    [Fact]
    public void InfoLogsAreConsumed()
    {
        string actual = string.Empty;

        void testLogger(Solutions.LogLevel level, string message)
        {
            string output = $"[{level}] - {message}";
            _testOutput.WriteLine(output);
            actual = output;
        }

        var consumeLog = (Solutions.Log log) =>
            log.Info("Test message");

        consumeLog(testLogger);

        Assert.Equal("[Info] - Test message", actual);
    }

    [Fact]
    public void DebugLogsAreConsumed()
    {
        string actual = string.Empty;

        void testLogger(Solutions.LogLevel level, string message)
        {
            string output = $"[{level}] - {message}";
            _testOutput.WriteLine(output);
            actual = output;
        }

        var consumeLog = (Solutions.Log log) =>
            log.Debug("Test message");

        consumeLog(testLogger);

        Assert.Equal("[Debug] - Test message", actual);
    }

    [Fact]
    public void ErrorLogsAreConsumed()
    {
        string actual = string.Empty;

        void testLogger(Solutions.LogLevel level, string message)
        {
            string output = $"[{level}] - {message}";
            _testOutput.WriteLine(output);
            actual = output;
        }

        var consumeLog = (Solutions.Log log) =>
            log.Error("Test message");

        consumeLog(testLogger);

        Assert.Equal("[Error] - Test message", actual);
    }

    [Fact]
    public void MapInTermsOfAggregate()
    {
        var range = Enumerable.Range(1, 5);
        var transform = (int i) => i.ToString(System.Globalization.CultureInfo.InvariantCulture);

        var actual = range.MapInTermsOfAggregate(transform);

        var expected = new string[] { "1", "2", "3", "4", "5" };
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void WhereInTermsOfAggregate()
    {
        var range = Enumerable.Range(1, 6);
        var predicate = (int i) => i % 2 == 0;

        var actual = range.WhereInTermsOfAggregate(predicate);

        var expected = new int[] { 2, 4, 6 };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BindInTermsOfAggregate()
    {
        var range = Enumerable.Range(1, 5);
        var binding = (int i) => new[] { -i, i };

        var actual = range.BindInTermsOfAggregate(binding);

        var expected = new[]
        {
            new [] { -1, 1 },
            new [] { -2, 2 },
            new [] { -3, 3 },
            new [] { -4, 4 },
            new [] { -5, 5 }
        };
        Assert.Equivalent(expected, actual);
    }
}