using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infratructure.EntitiesConfiguration;

public class MakerEntityConfiguration : IEntityTypeConfiguration<Maker>
{
    public void Configure(EntityTypeBuilder<Maker> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired(false);
    }
}
