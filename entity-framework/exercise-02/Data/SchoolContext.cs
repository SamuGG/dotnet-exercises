using EFDemo02.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemo02.Data;

public class SchoolContext : DbContext
{
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Enrollment> Enrollments { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    { }
}