var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var DbConnect = "Server=(localdb)\\mssqllocaldb;Database=Northwind;integrated security=true";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DbConnect));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(DbConnect));
builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Security/SignIn";
    options.AccessDeniedPath = "/Security/AccessDenied";
});


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
