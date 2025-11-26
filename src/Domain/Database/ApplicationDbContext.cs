using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<Dropdown> Dropdowns { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dropdown>()
            .HasMany(d => d.Children)
            .WithOne(d => d.Parent)
            .HasForeignKey(d => d.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        DataSeed.Seed(modelBuilder);
    }
}
