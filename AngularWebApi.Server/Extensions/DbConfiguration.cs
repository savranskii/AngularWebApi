using AngularWebApi.Infrastructure;
using AngularWebApi.Infrastructure.Models;

namespace AngularWebApi.Server.Extensions;

public static class DbConfiguration
{
    public static void ConfigureDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddSqlite<ApplicationDbContext>(builder.Configuration.GetConnectionString("SqlLite"));
    }

    public static void InitDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();
        dbContext.Seed();
    }

    private static void Seed(this ApplicationDbContext context)
    {
        if (context.Countries.Any())
            return;

        var countries = new List<Country>
        {
            new()
            {
                Id = 1, Name = "Country 1", Provinces =
                [
                    new Province { Id = 1, CountryId = 1, Name = "Province 1.1" },
                    new Province { Id = 2, CountryId = 1, Name = "Province 1.2" },
                    new Province { Id = 3, CountryId = 1, Name = "Province 1.3" }
                ]
            },
            new()
            {
                Id = 2, Name = "Country 2", Provinces =
                [
                    new Province { Id = 4, CountryId = 2, Name = "Province 2.1" },
                    new Province { Id = 5, CountryId = 2, Name = "Province 2.2" }
                ]
            }
        };
        context.AddRange(countries);
        context.SaveChanges();
    }
}