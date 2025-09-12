using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VoxTics;

using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data;


var builder = WebApplication.CreateBuilder(args);

// --- Services -----------------------------

// DbContext (SQL Server)
builder.Services.AddDbContext<MovieDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 8;
    option.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<MovieDbContext>()
    .AddDefaultTokenProviders();
// MVC
builder.Services.AddControllersWithViews()
   .AddJsonOptions(opt => {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    }
    );
// Repositories (extension method you created in VoxTics.Repositories)
builder.Services.AddApplicationServices();


// Useful for services/controllers that need HttpContext
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// --- Middleware pipeline ------------------

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// If you add Identity later:
// app.UseAuthentication();

app.UseAuthorization();

// Area route first
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
