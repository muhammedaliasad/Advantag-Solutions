using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SalesStat> SalesStats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<SalesStat>().HasData(
            new SalesStat { Id = 1, Date = DateTime.UtcNow.AddDays(-1), Amount = 100.50m, Category = "Electronics", TransactionCount = 5 },
            new SalesStat { Id = 2, Date = DateTime.UtcNow.AddDays(-2), Amount = 200.75m, Category = "Books", TransactionCount = 10 },
            new SalesStat { Id = 3, Date = DateTime.UtcNow.AddDays(-3), Amount = 50.00m, Category = "Clothing", TransactionCount = 2 },
            new SalesStat { Id = 4, Date = DateTime.UtcNow.AddDays(-4), Amount = 300.20m, Category = "Electronics", TransactionCount = 8 },
            new SalesStat { Id = 5, Date = DateTime.UtcNow.AddDays(-5), Amount = 150.00m, Category = "Home", TransactionCount = 6 }
        );
    }
}
