using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VoxTics.Data;
using VoxTics.MappingProfiles;
using VoxTics.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- Services -----------------------------

// DbContext (SQL Server)
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC
builder.Services.AddControllersWithViews();

// Repositories (extension method you created in VoxTics.Repositories)
builder.Services.AddVoxTicsRepositories();

// AutoMapper profiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MovieProfile>();
    cfg.AddProfile<CategoryProfile>();
    cfg.AddProfile<CinemaProfile>();
    cfg.AddProfile<ShowtimeProfile>();

});

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
