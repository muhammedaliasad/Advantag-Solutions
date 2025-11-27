using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Forecast> Forecasts { get; set; } = null!;
    public DbSet<ForecastActual> ForecastActuals { get; set; } = null!;
    public DbSet<Dropdown> Dropdowns { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dropdown>()
            .HasMany(d => d.Children)
            .WithOne(d => d.Parent)
            .HasForeignKey(d => d.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Forecast>()
            .HasMany(f => f.Actuals)
            .WithOne()
            .HasForeignKey(a => a.ForecastId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ForecastActual>()
            .Property(a => a.Amount)
            .HasPrecision(18, 2);

        DataSeed.Seed(modelBuilder);
    }
}
