using Microsoft.EntityFrameworkCore;

namespace CloudWeather.Precipitation.DataAccess;

public class PrecipitationDbContext : DbContext
{
    public PrecipitationDbContext() {}
    public PrecipitationDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Precipitation> Precipitation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SnakeCaseIdentityTableNames(modelBuilder);
    }

    private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Precipitation>(builder => builder.ToTable("precipitation"));
    }
}