using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroformLite.Infrastructure.Database.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
    }
}
