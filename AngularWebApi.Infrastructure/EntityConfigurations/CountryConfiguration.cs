using AngularWebApi.Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularWebApi.Infrastructure.EntityConfigurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired();
        builder.HasIndex(c => c.Name).IsUnique();
        builder.HasMany(c => c.Provinces)
            .WithOne(p => p.Country)
            .HasForeignKey(p => p.CountryId)
            .IsRequired();
        builder.HasData(new List<Country>
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
        });
    }
}