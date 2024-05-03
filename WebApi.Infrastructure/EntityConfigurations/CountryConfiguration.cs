using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.UserAggregate.Entities;

namespace WebApi.Infrastructure.EntityConfigurations;

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
            new(1, "Country 1"),
            new(2, "Country 2")
        });
    }
}