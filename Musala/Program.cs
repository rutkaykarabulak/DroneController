using Microsoft.EntityFrameworkCore;
using Musala.EFModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSQLDbContext>(option =>
option.UseNpgsql(builder.Configuration.GetConnectionString("Musala_postgresDb")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
