using AdvAsmPlanning.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdvAsmPlanning.Domain.Database;

public static class DataSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // ------------------------
        //  FIXED IDs FOR SEEDING
        // ------------------------
        const long adminRoleId = 1001;
        const long adminUserId = 1002;

        // Static date (not dynamic, safe for EF seed)
        var seedDate = new DateTime(2025, 11, 27, 14, 30, 0, DateTimeKind.Utc);

        // -----------------------------------------------------------
        //  SEED ADMIN ROLE (STATIC GUIDS = NO PENDING MODEL CHANGES)
        // -----------------------------------------------------------
        modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "6A1E2C53-874C-4710-9828-5C761B5919BD"
            }
        );

        // -----------------------------------------------------------
        //  SEED ADMIN USER (STATIC PASSWORD HASH)
        //  Password:  Admin123!
        // -----------------------------------------------------------
        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,

                SecurityStamp = "C88FA612-1790-4B5B-9AA0-560F50FC7B72",
                ConcurrencyStamp = "B0A3D1CF-679E-4C9E-92A7-2FDFB5C01F44",

                PasswordHash = "AQAAAAIAAYagAAAAEFj9Zqgbi0FbS0mMGtPpXyQt1K2dI4XFa7Q0Jm4ByfgfH5AjFq5RZkGW9xO+fAO3KA=="
            }
        );

        // -----------------------------------------------------------
        //  ASSIGN USER TO ADMIN ROLE
        // -----------------------------------------------------------
        modelBuilder.Entity<IdentityUserRole<long>>().HasData(
            new IdentityUserRole<long>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });
    }
}
