using AdvAsmPlanning.Domain.Entities;

namespace AdvAsmPlanning.Domain.Database;

public static class MainGridDataSeeder
{
    public static async Task SeedMainGridsAsync(ApplicationDbContext context)
    {
        // Check if main grids already exist
        if (await context.MainGrids.AnyAsync())
        {
            return; // Data already seeded
        }

        // Fixed timestamp for all seeded data to prevent migration issues
        var seedTimestamp = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var random = new Random(42); // Fixed seed for reproducible data

        var clients = new[] { "Acme Corp", "TechSolutions Inc", "Global Industries", "Digital Ventures", "Enterprise Systems", "Innovation Labs", "Future Tech", "Smart Solutions", "NextGen Corp", "Advanced Systems" };
        var customers = new[] { "Customer A", "Customer B", "Customer C", "Customer D", "Customer E", "Customer F", "Customer G", "Customer H", "Customer I", "Customer J" };
        var sizes = new[] { "Small", "Medium", "Large", "Extra Large" };
        var goFindOptions = new[] { "Yes", "No", "Pending" };
        var projectTypes = new[] { "Web Development", "Mobile App", "Cloud Migration", "Data Analytics", "AI Integration", "Security Audit", "System Upgrade", "API Development", "Database Optimization", "Infrastructure Setup" };

        var mainGrids = new List<MainGrid>();

        for (int i = 1; i <= 100; i++)
        {
            var client = clients[random.Next(clients.Length)];
            var customer = customers[random.Next(customers.Length)];
            var size = sizes[random.Next(sizes.Length)];
            var goFind = goFindOptions[random.Next(goFindOptions.Length)];
            var projectType = projectTypes[random.Next(projectTypes.Length)];

            // Generate Delta: 30% null, 35% positive, 35% negative (integer values)
            int? delta = null;
            var deltaChance = random.Next(100);
            if (deltaChance < 35)
            {
                delta = random.Next(10, 500); // Positive delta (integer)
            }
            else if (deltaChance < 70)
            {
                delta = -random.Next(10, 500); // Negative delta (integer)
            }
            // else delta remains null

            // Generate Account No (format: ACC-XXX)
            var accountNo = $"ACC-{random.Next(1000, 9999):D4}";

            // Generate Department No (format: DEPT-XXX)
            var departmentNo = $"DEPT-{random.Next(100, 999):D3}";

            var mainGrid = new MainGrid
            {
                Client = client,
                Customer = customer,
                SizeProject = size,
                Project = $"{projectType} - Project {i}",
                GoFind = goFind,
                Comment = $"Main grid entry #{i} - {projectType} for {client}",
                Delta = delta,
                AccountNo = accountNo,
                DepartmentNo = departmentNo,
                CreatedAt = seedTimestamp
            };

            // Add 12 months of actuals for 2024 (one per month)
            for (int month = 1; month <= 12; month++)
            {
                var baseAmount = random.Next(10000, 100000);
                mainGrid.Actuals.Add(new MainGridActual
                {
                    Year = 2024,
                    Month = month,
                    Amount = Math.Round((decimal)baseAmount + (random.Next(-5000, 5000)), 2),
                    CreatedAt = seedTimestamp
                });
            }

            // Add 12 months of actuals for 2025 (one per month)
            for (int month = 1; month <= 12; month++)
            {
                var baseAmount = random.Next(10000, 100000);
                mainGrid.Actuals.Add(new MainGridActual
                {
                    Year = 2025,
                    Month = month,
                    Amount = Math.Round((decimal)baseAmount + (random.Next(-5000, 5000)), 2),
                    CreatedAt = seedTimestamp
                });
            }

            mainGrids.Add(mainGrid);
        }

        await context.MainGrids.AddRangeAsync(mainGrids);
        await context.SaveChangesAsync();
    }
}

