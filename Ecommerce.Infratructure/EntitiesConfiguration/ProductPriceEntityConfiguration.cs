using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infratructure.EntitiesConfiguration;

public class ProductPriceEntityConfiguration : IEntityTypeConfiguration<ProductPrice>
{
    public void Configure(EntityTypeBuilder<ProductPrice> builder)
    {
        builder.Property(x => x.Price).IsRequired();
        builder.Property(c => c.CreatedAt).IsRequired();

        builder.HasOne(p => p.Creator).WithMany()
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
