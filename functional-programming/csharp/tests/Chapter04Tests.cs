using FunctionalProgramming.Exercises.Chapter04;
using FP = LaYumba.Functional;

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

    public static TheoryData<FP.Option<int>, FP.Option<DayOfWeek>> MapOptionTestData => new()
    {
        { FP.F.Some(1) , FP.F.Some(DayOfWeek.Monday) },
        { FP.F.Some(2) , FP.F.Some(DayOfWeek.Tuesday) },
        { FP.F.None, FP.F.None }
    };

    [Theory]
    [MemberData(nameof(MapOptionTestData))]
    public void MapOptionOfIntToOptionOfDay(FP.Option<int> dayNumber, FP.Option<DayOfWeek> dayOfWeek)
    {
        var dayNumberToDayOfWeek = new Func<int, DayOfWeek>(i => (DayOfWeek)i);

        var actual = dayNumber.Map(dayNumberToDayOfWeek);

        Assert.Equal(dayOfWeek, actual);
    }

    public static TheoryData<IEnumerable<int>, IEnumerable<IEnumerable<int>>> MapEnumerableTestData => new()
    {
        {
            new[] {-5, 0, 3},
            new[] {
                new[] { -5 },
                new[] { 0 },
                new[] { 3 }
            }
        },
        { Enumerable.Empty<int>(), Enumerable.Empty<IEnumerable<int>>() }
    };

    [Theory]
    [MemberData(nameof(MapEnumerableTestData))]
    public void MapEnumerableOfIntToEnumerableOfEnumerables(IEnumerable<int> ints, IEnumerable<IEnumerable<int>> expected)
    {
        var toEnumerable = new Func<int, IEnumerable<int>>(i => new[] { i });

        var actual = ints.Map(toEnumerable);

        Assert.Equivalent(expected, actual);
    }

    public static TheoryData<Dictionary<string, Employee>, string, FP.Option<WorkPermit>> WorkPermitTestData => new()
    {
        {
            new Dictionary<string, Employee>(),
            "ID-01",
            FP.F.None
        },
        {
            new Dictionary<string, Employee>
            {
                {"ID-01", new Employee()}
            },
            "ID-01",
            FP.F.None
        },
        {
            new Dictionary<string, Employee>
            {
                {"ID-01", new Employee { WorkPermit = FP.F.Some(new WorkPermit())}}
            },
            "ID-01",
            FP.F.Some(new WorkPermit())
        }
    };

    [Theory]
    [MemberData(nameof(WorkPermitTestData))]
    public void GetWorkPermit(Dictionary<string, Employee> people, string employeeId, FP.Option<WorkPermit> expected)
    {
        var actual = Solutions.GetWorkPermit(people, employeeId);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Dictionary<string, Employee>, string, FP.Option<WorkPermit>> ValidWorkPermitTestData => new()
    {
        {
            new Dictionary<string, Employee>(),
            "ID-01",
            FP.F.None
        },
        {
            new Dictionary<string, Employee>
            {
                {"ID-01", new Employee()}
            },
            "ID-01",
            FP.F.None
        },
        {
            new Dictionary<string, Employee>
            {
                {"ID-01", new Employee { WorkPermit = FP.F.Some(new WorkPermit{ Expiry = DateTime.Today.AddDays(-1)})}}
            },
            "ID-01",
            FP.F.None
        },
        {
            new Dictionary<string, Employee>
            {
                {"ID-01", new Employee { WorkPermit = FP.F.Some(new WorkPermit{ Expiry = DateTime.Today.AddDays(1)})}}
            },
            "ID-01",
            FP.F.Some(new WorkPermit{ Expiry = DateTime.Today.AddDays(1)})
        }
    };

    [Theory]
    [MemberData(nameof(ValidWorkPermitTestData))]
    public void GetValidWorkPermit(Dictionary<string, Employee> people, string employeeId, FP.Option<WorkPermit> expected)
    {
        var actual = Solutions.GetValidWorkPermit(people, employeeId);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<Employee[], double> AverageYearsTestData => new()
    {
        {
            Array.Empty<Employee>(),
            0.0
        },
        {
            new Employee[]
            {
                new Employee { JoinedOn = DateTime.Today, LeftOn = FP.F.None }
            },
            0.0
        },
        {
            new Employee[]
            {
                new Employee { JoinedOn = DateTime.Today.AddYears(-2), LeftOn = FP.F.Some(DateTime.Today.AddYears(-1)) },
                new Employee { JoinedOn = DateTime.Today.AddYears(-2), LeftOn = FP.F.Some(DateTime.Today.AddMonths(-6)) },
                new Employee { JoinedOn = DateTime.Today, LeftOn = FP.F.None }
            },
            1.25
        }
    };

    [Theory]
    [MemberData(nameof(AverageYearsTestData))]
    public void AverageYearsWorked(Employee[] employees, double expected)
    {
        double actual = Solutions.AverageYearsWorkedAtTheCompany(employees.AsReadOnly());
        Assert.Equal(expected, actual, 2);
    }
}