using Kolokwium.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectsDbContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=ProjectsSystem;User=sa;Password=Docker@123;Persist Security Info=False;Encrypt=False;trusted_connection=false");
});

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

