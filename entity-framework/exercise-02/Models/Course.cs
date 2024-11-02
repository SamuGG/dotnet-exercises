using System.ComponentModel.DataAnnotations;

namespace EFDemo02.Models;

public class Course
{
    public int CourseId { get; set; }

    [Required]
    public string Title { get; set; } = default!;

    [Range(0, 10)]
    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}