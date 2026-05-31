using ECommerce516.Utitlity.DBInitializer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Stripe;
using VoxTics;
using VoxTics.Helpers.booking;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var configuration = builder.Configuration;

// Add services to the container
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>)); 
builder.Services.AddScoped<IAdminMoviesRepository, AdminMoviesRepository>();     
builder.Services.AddScoped<IAdminMovieService, AdminMovieService>();            
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();                           
builder.Services.AddAutoMapper(typeof(AdminMovieProfile));

// Database context with connection string from environment or config
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") 
    ?? configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
        sqlOptions.CommandTimeout(30);
    }));

// ASP.NET Core Identity with enhanced security
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.User.RequireUniqueEmail = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<MovieDbContext>()
.AddDefaultTokenProviders();

// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register custom services, repositories, UnitOfWork, etc.
builder.Services.AddVoxTicsServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Configure application cookie - use SameSiteMode.None/Lax for proxy compatibility
builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/Identity/Account/Login";
    option.AccessDeniedPath = "/Shared/AccessDenied";
    option.ExpireTimeSpan = TimeSpan.FromHours(1);
    option.SlidingExpiration = true;
    option.Cookie.HttpOnly = true;
    option.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    option.Cookie.SameSite = SameSiteMode.Lax;
});

// Configure forwarded headers for Replit proxy
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Configure Stripe
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
var stripeKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY") 
    ?? builder.Configuration["Stripe:SecretKey"];
StripeConfiguration.ApiKey = stripeKey;

// Add health checks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<MovieDbContext>();

var app = builder.Build();

// Use forwarded headers before anything else
app.UseForwardedHeaders();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}
else
{
    app.UseDeveloperExceptionPage();
}

// Security headers middleware
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");
    context.Response.Headers.Append("Permissions-Policy", "geolocation=(), microphone=(), camera=()");
    await next();
});

app.UseStatusCodePagesWithReExecute("/Shared/NotFound");
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Health check endpoint
app.MapHealthChecks("/health");

// Initialize database
try
{
    var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider.GetService<IDBInitializer>();
    service?.Initialize();
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while initializing the database.");
    if (!app.Environment.IsDevelopment())
        throw;
}

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
