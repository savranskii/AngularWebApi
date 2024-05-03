using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.UserAggregate.Entities;

namespace WebApi.Infrastructure.EntityConfigurations;

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
            new(1, 1, "Province 1.1"),
            new(2, 1, "Province 1.2"),
            new(3, 1, "Province 1.3"),
            new(4, 2, "Province 2.1"),
            new(5, 2, "Province 2.2")
        });
    }
}