using AngularWebApi.ApplicationCore.Entities;
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
    }
}