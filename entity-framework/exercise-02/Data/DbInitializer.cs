using EFDemo02.Models;

namespace EFDemo02.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(SchoolContext context)
    {
        if (context.Students.Any())
            return;

        var courses = new Course[]
        {
            new() { Title = "Course-01", Credits = 1 },
            new() { Title = "Course-02", Credits = 5 },
            new() { Title = "Course-03", Credits = 8 }
        };

        var students = new Student[]
        {
            new() { FirstName = "Adam", LastName = "Adams"},
            new() { FirstName = "Ben", LastName = "Benny"},
            new() { FirstName = "Charles", LastName = "Charlie"},
            new() { FirstName = "Diana", LastName = "Dina"},
            new() { FirstName = "Fiona", LastName = "Fio"}
        };

        await context.Courses.AddRangeAsync(courses).ConfigureAwait(false);
        await context.Students.AddRangeAsync(students).ConfigureAwait(false);
        await context.SaveChangesAsync().ConfigureAwait(false);

        var enrollments = new Enrollment[]
        {
            new() { Course = courses.First(), Student = students.First(), Date = DateTime.Today.AddMonths(-1), Grade = Grade.C },
            new() { Course = courses.First(), Student = students.Skip(1).First(), Date = DateTime.Today.AddMonths(-1), Grade = Grade.B },
            new() { Course = courses.First(), Student = students.Skip(2).First(), Date = DateTime.Today.AddDays(-10) },
            new() { Course = courses.Skip(1).First(), Student = students.Skip(1).First(), Date = DateTime.Today.AddDays(-1), Grade = Grade.F },
            new() { Course = courses.Skip(1).First(), Student = students.Skip(3).First(), Date = DateTime.Today },
            new() { Course = courses.Last(), Student = students.Skip(3).First(), Date = DateTime.Today.AddDays(-3), Grade = Grade.D },
            new() { Course = courses.Last(), Student = students.Skip(4).First(), Date = DateTime.Today },
        };

        await context.Enrollments.AddRangeAsync(enrollments).ConfigureAwait(false);
        await context.SaveChangesAsync().ConfigureAwait(false);
    }
}