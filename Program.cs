using Microsoft.EntityFrameworkCore;
using PschoolAPI.Data;
using PschoolAPI.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL and EF Core
builder.Services.AddDbContext<PschoolContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add logging services
builder.Services.AddLogging();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow all origins
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure logging
var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<PschoolContext>();
        context.Database.CanConnect(); // Attempt to connect to the database
        logger.LogInformation("Database connection successful.");
    }
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while connecting to the database.");
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
