using AdvAsmPlanning.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvAsmPlanning.Domain.Database;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Forecast> Forecasts { get; set; } = null!;
    public DbSet<ForecastActual> ForecastActuals { get; set; } = null!;
    public DbSet<Dropdown> Dropdowns { get; set; } = null!;
    public DbSet<PlanningScenario> PlanningScenarios { get; set; } = null!;


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
            .WithOne(a => a.Forecast)
            .HasForeignKey(a => a.ForecastId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ForecastActual>()
            .Property(a => a.Amount)
            .HasPrecision(18, 2);

        DataSeed.Seed(modelBuilder);
    }
}
