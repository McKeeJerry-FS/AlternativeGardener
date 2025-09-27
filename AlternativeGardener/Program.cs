using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AlternativeGardener.Data;
using AlternativeGardener.Models;
using AlternativeGardener.Services;
using AlternativeGardener.Services.Interfaces;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models; // add this
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var useAzureDb = builder.Configuration.GetValue<bool>("UseAzureDb");
var connStrName = useAzureDb
    ? "AzureConnection"
    : (builder.Environment.IsDevelopment() ? "DefaultConnection" : "AzureConnection");

var connectionString = builder.Configuration.GetConnectionString(connStrName)
    ?? throw new InvalidOperationException($"Connection string '{connStrName}' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
           .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0); // Set default version
    options.AssumeDefaultVersionWhenUnspecified = true; // Use default if no version is specified
    options.ReportApiVersions = true; // Include API versions in response headers
});

// App services
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IGardenService, GardenService>();
builder.Services.AddScoped<IPlantService, PlantService>();
builder.Services.AddScoped<IRecordService, RecordService>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews(); // alongside AddRazorPages()

// Ensure enums serialize/deserialize as strings in API responses/requests
builder.Services.AddControllersWithViews()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AlternativeGardener API",
        Version = "v1"
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "AlternativeGardener API",
        Version = "v2"
    });
});

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
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlternativeGardener API v1");
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlternativeGardener API v2");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

    // Optionally enable Swagger in non-dev
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlternativeGardener API v1");
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlternativeGardener API v2");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

// Map attribute-routed API controllers (required for your [Route]/[Http...] attributes)
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
