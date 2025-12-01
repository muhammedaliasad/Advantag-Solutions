using AdvAsmPlanning.Domain.Database;
using AdvAsmPlanning.Infrastructure.Interfaces;
using AdvAsmPlanning.Infrastructure.Repositories;
using AdvAsmPlanning.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;


namespace AdvAsmPlanning.Infrastructure;

public static class AppRegistrationCollectionExtension
{
    public static void RegisterAppDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name);
                }), ServiceLifetime.Scoped);
    }

    // Dependency Injection
    public static void RegisterAppServices(this IServiceCollection services)
    {
        // Add Application Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Dropdown service registration
        services.AddScoped<IDropdownService, DropdownService>();

        // Auth service
        services.AddSingleton<IAuthService, AuthService>();

        // Forecast service registration
        services.AddScoped<IForecastService, ForecastService>();
    }

    public static void ConfigureSwaggerJwtAuthentication(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Advance ASM Planning", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("bearer", document)] = []
            });
        });
    }


    public static void ConfigureJwtTokenValidation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        })
        .AddJwtBearer("Bearer", options =>
        {
            //options.Authority = "https://identity-provider.com"; // If using an identity provider (e.g., IdentityServer)
            //options.Audience = "your-api"; // The audience for the token
            //options.RequireHttpsMetadata = false; // Set to true in production

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)
                )
            };
        });
    }
}
