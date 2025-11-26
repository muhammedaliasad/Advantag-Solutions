using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DbContext>(options => options.UseSqlServer(connectionString, actions =>
        {
            actions.MigrationsAssembly(nameof(Infrastructure));
        }), ServiceLifetime.Scoped);

        // Add Application Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Add Application Services
        services.AddScoped<ISalesService, SalesService>();
    }
}
