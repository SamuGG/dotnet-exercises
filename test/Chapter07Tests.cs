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
}