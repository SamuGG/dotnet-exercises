using FunctionalProgramming.Exercises.Chapter06;
using LaYumba.Functional;

namespace FunctionalProgramming.Exercises.Tests.Chapter06;

public class SolutionsTests
{
    public static TheoryData<Either<bool, int>, Option<int>> EitherToOptionTestData => new()
    {
        { F.Left(false), F.None },
        { F.Right(21), F.Some(21) }
    };

    [Theory]
    [MemberData(nameof(EitherToOptionTestData))]
    public void EitherToOption(Either<bool, int> sut, Option<int> expected)
    {
        var actual = sut.ToOption();
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Option<int>, Func<bool>, Either<bool, int>> OptionToEitherTestData => new()
    {
        { F.None, () => true, F.Left(true) },
        { F.Some(21), () => false, F.Right(21) }
    };

    [Theory]
    [MemberData(nameof(OptionToEitherTestData))]
    public void OptionToEither(Option<int> sut, Func<bool> left, Either<bool, int> expected)
    {
        var actual = sut.ToEither(left);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<string, Option<Solutions.Age>> ParseEitherTestData => new()
    {
        { "-23", F.None },
        { "23", Solutions.Age.Of(23) }
    };

    [Theory]
    [MemberData(nameof(ParseEitherTestData))]
    public void ParseEither(string candidate, Option<Solutions.Age> expected)
    {
        var actual = Solutions.ParseAge(candidate);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrySuccessfulFunction()
    {
        const int value = 304;
        var f = new Func<int>(() => value);

        var actual = Solutions.Try(f);

        actual.Match(
            ex => Assert.Fail("Exception with success state expected but got error state instead"),
            r => Assert.Equal(value, r));
    }

    [Fact]
    public void TryFailureFunction()
    {
        var expected = new NotImplementedException();
        var f = new Func<int>(() => throw expected);

        var actual = Solutions.Try(f);

        actual.Match(
            ex => Assert.Equal(expected, ex),
            r => Assert.Fail("Exceptional with error state expected but got success state instead"));
    }
}