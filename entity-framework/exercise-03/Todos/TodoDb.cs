using Microsoft.EntityFrameworkCore;

namespace EFDemo03.Todos;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}