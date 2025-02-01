﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infratructure.EntitiesConfiguration;

public class ProductDiscountEntityConfiguration : IEntityTypeConfiguration<ProductDiscount>
{
    public void Configure(EntityTypeBuilder<ProductDiscount> builder)
    {
        builder.Property(x => x.Discount).IsRequired();
        builder.ToTable(x => 
                        x.HasCheckConstraint("CK_Discount_Range", 
                             "\"ProductDiscount\".\"Discount\" >= 0 AND \"ProductDiscount\".\"Discount\" <= 1"));
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.HasOne(p => p.Creator).WithMany()
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
