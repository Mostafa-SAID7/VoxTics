using ECommerce516.Utitlity.DBInitializer;
using Microsoft.AspNetCore.Identity;
using Stripe;
using VoxTics;
using VoxTics.Helpers.booking;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var configuration = builder.Configuration;

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>)); 
builder.Services.AddScoped<IAdminMoviesRepository, AdminMoviesRepository>();     
builder.Services.AddScoped<IAdminMovieService, AdminMovieService>();            
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();                           
builder.Services.AddAutoMapper(typeof(AdminMovieProfile));

// Database context
builder.Services.AddScoped<IDBInitializer, DBInitializer>();

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
builder.Services.AddVoxTicsServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/Identity/Account/Login";
    option.AccessDeniedPath = "/Shared/AccessDenied";
});

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
app.UseStatusCodePagesWithReExecute("/Shared/NotFound");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetService<IDBInitializer>();
service.Initialize();
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
