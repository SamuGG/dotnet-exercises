using System.ComponentModel.DataAnnotations;

namespace EFDemo02.Models;

public class Student
{
    public int StudentId { get; set; }

    [Required]
    public string FirstName { get; set; } = default!;

    [Required]
    public string LastName { get; set; } = default!;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}