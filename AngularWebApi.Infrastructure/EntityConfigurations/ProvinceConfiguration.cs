using AngularWebApi.Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularWebApi.Infrastructure.EntityConfigurations;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired();
        builder.HasIndex(c => c.Name).IsUnique();
        builder.HasOne(c => c.Country)
            .WithMany(p => p.Provinces)
            .IsRequired();

        builder.HasData(new List<Province>
        {
            new() { Id = 1, CountryId = 1, Name = "Province 1.1" },
            new() { Id = 2, CountryId = 1, Name = "Province 1.2" },
            new() { Id = 3, CountryId = 1, Name = "Province 1.3" },
            new() { Id = 4, CountryId = 2, Name = "Province 2.1" },
            new() { Id = 5, CountryId = 2, Name = "Province 2.2" }
        });
    }
}