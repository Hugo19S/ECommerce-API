using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infratructure.EntitiesConfiguration;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Sku).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.Model).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired(false);

        builder.HasOne(p => p.Creator).WithMany()
            .HasForeignKey(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Updater).WithMany()
            .HasForeignKey(p => p.UpdatedBy)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
