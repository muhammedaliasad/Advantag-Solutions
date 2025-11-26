using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database;

public static class DataSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>().HasData(
             new Sale { Id = 1, Date = DateTime.UtcNow.AddDays(-1), Amount = 100.50m },
             new Sale { Id = 2, Date = DateTime.UtcNow.AddDays(-2), Amount = 200.75m },
             new Sale { Id = 3, Date = DateTime.UtcNow.AddDays(-3), Amount = 50.00m },
             new Sale { Id = 4, Date = DateTime.UtcNow.AddDays(-4), Amount = 300.20m },
             new Sale { Id = 5, Date = DateTime.UtcNow.AddDays(-5), Amount = 150.00m }
         );
    }
}

