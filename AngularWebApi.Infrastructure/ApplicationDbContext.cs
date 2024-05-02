using AngularWebApi.Domain.Seeds;
using AngularWebApi.Domain.UserAggregate.Entities;
using AngularWebApi.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AngularWebApi.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Province> Provinces => Set<Province>();

    public async Task SaveEntitiesAsync(CancellationToken ct = default)
    {
        await base.SaveChangesAsync(ct);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
    }
}