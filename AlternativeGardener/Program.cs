using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AlternativeGardener.Data;
using AlternativeGardener.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var useAzureDb = builder.Configuration.GetValue<bool>("UseAzureDb");
var connStrName = useAzureDb
    ? "AzureConnection"
    : (builder.Environment.IsDevelopment() ? "DefaultConnection" : "AzureConnection");

var connectionString = builder.Configuration.GetConnectionString(connStrName)
    ?? throw new InvalidOperationException($"Connection string '{connStrName}' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Apply any pending EF Core migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
