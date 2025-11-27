using Domain.Database;
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
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name);
            }), ServiceLifetime.Scoped);

        // Add Application Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Dropdown service registration
        services.AddScoped<IDropdownService, DropdownService>();
        
        // Forecast service registration
        services.AddScoped<IForecastService, ForecastService>();
    }
}
