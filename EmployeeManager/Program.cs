using EmployeeManager.Models;
using EmployeeManager.Security;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var DbConnect = "Server=(localdb)\\mssqllocaldb;Database=Northwind;integrated security=true";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DbConnect));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(DbConnect));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeManager}/{action=List}/{id?}");

app.Run();