using AlternativeGardener.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlternativeGardener.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Garden> Gardens { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<Chemical> Chemicals { get; set; }
    
}
