using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Sale> Sales { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DataSeed.Seed(modelBuilder);
    }
}
