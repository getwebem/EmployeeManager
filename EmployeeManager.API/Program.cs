using EmployeeManager.API.Models;
using EmployeeManager.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var DbConnect = "Server=(localdb)\\mssqllocaldb;Database=Northwind;integrated security=true";
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DbConnect));
builder.Services.AddScoped<IEmployeeRepository, EmployeeSqlRepository>();

var app = builder.Build();

bool IsDevelopment()
{
    throw new NotImplementedException();
}

app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

app.Run();
