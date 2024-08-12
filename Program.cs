using Microsoft.EntityFrameworkCore;
using PschoolAPI.Data;
using PschoolAPI.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL and EF Core
builder.Services.AddDbContext<PschoolContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddLogging(); // Add logging services

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
