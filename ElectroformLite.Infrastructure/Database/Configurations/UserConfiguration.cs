using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroformLite.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        /*builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60);

        builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(60);*/
    }
}
