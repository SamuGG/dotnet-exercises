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
}