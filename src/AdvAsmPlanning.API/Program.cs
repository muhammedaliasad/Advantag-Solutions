var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register AutoMapper (ensure profiles are discovered)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register Application Services
builder.Services.RegisterAppDatabase(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.RegisterAppServices();

// Swagger with JWT
builder.Services.ConfigureSwaggerJwtAuthentication();

// Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// JWT Authentication
builder.Services.ConfigureJwtTokenValidation(builder.Configuration);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("*", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
    );
});

// Build
var app = builder.Build();

// Enable CORS policy
app.UseCors("*");

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advantag Solutions API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

// Global Exception Handler
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Ensure DB
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.MigrateAsync().GetAwaiter().GetResult();

    // Seed Forecast data if it doesn't exist
    await ForecastDataSeeder.SeedForecastsAsync(context);

    // Seed Planning Scenario data if it doesn't exist
    await PlanningScenarioDataSeeder.SeedPlanningScenarios(context);
}

app.Run();
