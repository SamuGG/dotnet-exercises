using System.ComponentModel.DataAnnotations;

namespace EFDemo02.Models;

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public DateTime Date { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; } = default!;

    public int StudentId { get; set; }
    public Student Student { get; set; } = default!;

    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade { get; set; }
}

public enum Grade
{
    A, B, C, D, F
}