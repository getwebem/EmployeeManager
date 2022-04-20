using EmployeeManager.APIClient.Security;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var DbConnect = "Server=(localdb)\\mssqllocaldb;Database=Northwind;integrated security=true";

var BaseUrl = "http://localhost:17003";


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(DbConnect));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(DbConnect));
builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Security/SignIn";
    options.AccessDeniedPath = "/Security/AccessDenied";
});

HttpClient client = new HttpClient();
client.BaseAddress = new Uri(BaseUrl);
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
builder.Services.AddSingleton<HttpClient>(client);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=EmployeeManager}/{action=List}/{id?}");

app.Run();
