using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VoxTics.Data;
using VoxTics.Extensions;
using VoxTics.Models.Entities;
using VoxTics.Areas.Identity.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var configuration = builder.Configuration;

// Database context
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// ASP.NET Core Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.User.RequireUniqueEmail = false;
})
.AddEntityFrameworkStores<MovieDbContext>()
.AddDefaultTokenProviders();

// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register custom services, repositories, UnitOfWork, etc.
builder.Services.AddApplicationServices(configuration);

// AutoMapper profiles (if your profiles are in the same assembly)
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Area routing
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
