using AdvAsmPlanning.Domain.Entities;

namespace AdvAsmPlanning.Domain.Database;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<MainGrid> MainGrids { get; set; } = null!;
    public DbSet<MainGridActual> MainGridActuals { get; set; } = null!;
    public DbSet<Scenario> Scenarios { get; set; } = null!;

    public DbSet<Account> Account { get; set; } = null!;
    public DbSet<Department> Department { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MainGrid>()
            .HasMany(f => f.Actuals)
            .WithOne(a => a.MainGrid)
            .HasForeignKey(a => a.MainGridId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MainGridActual>()
            .Property(a => a.Amount)
            .HasPrecision(18, 2);

        DataSeed.Seed(modelBuilder);
    }
}
