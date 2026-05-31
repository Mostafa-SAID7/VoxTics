using ECommerce516.Utitlity.DBInitializer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Stripe;
using VoxTics;
using VoxTics.Helpers.booking;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Database context
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
        sqlOptions.CommandTimeout(30);
    }));

// ASP.NET Core Identity
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

// All services, repositories, AutoMapper profiles
builder.Services.AddVoxTicsServices(builder.Configuration);

// Application cookie
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

// Forwarded headers for Replit proxy
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Stripe
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY")
    ?? builder.Configuration["Stripe:SecretKey"];

// Health checks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<MovieDbContext>();

var app = builder.Build();

app.UseForwardedHeaders();

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

app.MapHealthChecks("/health");

try
{
    var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetService<IDBInitializer>()?.Initialize();
}
catch (Exception ex)
{
    app.Services.GetRequiredService<ILogger<Program>>()
        .LogError(ex, "An error occurred while initializing the database.");
    if (!app.Environment.IsDevelopment())
        throw;
}

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
