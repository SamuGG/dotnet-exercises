using FunctionalProgramming.Exercises.Chapter07;

namespace FunctionalProgramming.Exercises.Tests.Chapter07;

public class SolutionsTests
{
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
    public void ApplyRightmostParameter()
    {
        var binaryFunc = new Func<string, string, string>((a, b) =>
            string.Join(':', a, b));

        var unaryFunc = binaryFunc.ApplyR("right");

        string actual = unaryFunc("left");

        Assert.Equal("left:right", actual);
    }
}