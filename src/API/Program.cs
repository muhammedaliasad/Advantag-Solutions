using API.Middleware;
using Domain.Database;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Advantag Solutions API",
        Version = "v1",
        Description = "API for Advantag Solutions Management System"
    });
    
    // Ignore circular references
    c.CustomSchemaIds(type => type.FullName);
});

// Add Infrastructure
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection")!);

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("*",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advantag Solutions API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

// Global Exception Handler (after Swagger to avoid interfering with Swagger requests)
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors("*");

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.MigrateAsync().GetAwaiter().GetResult();
    
    // Seed Forecast data if it doesn't exist
    await ForecastDataSeeder.SeedForecastsAsync(context);
}

app.Run();
