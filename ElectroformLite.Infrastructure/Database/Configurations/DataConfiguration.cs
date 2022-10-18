using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroformLite.Infrastructure.Database.Configurations;

public class DataConfiguration : IEntityTypeConfiguration<Data>
{
    public void Configure(EntityTypeBuilder<Data> builder)
    {
        builder.Property(e => e.DataGroup)
                .IsRequired();
    }
}
