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
}