using AngularWebApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularWebApi.Infrastructure.EntityConfigurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Login).IsRequired();
        builder.HasIndex(u => u.Login).IsUnique();
        builder.HasOne(u => u.Country);
        builder.HasOne(u => u.Province);
        builder.Property(u => u.CreatedAt);
    }
}
