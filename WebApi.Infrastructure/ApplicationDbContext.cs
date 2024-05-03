using Microsoft.EntityFrameworkCore;
using WebApi.Domain.UserAggregate.Entities;
using WebApi.Infrastructure.EntityConfigurations;

namespace WebApi.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Province> Provinces => Set<Province>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
    }
}