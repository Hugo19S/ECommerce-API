using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infratructure.EntitiesConfiguration;

public class PaymentStatusHistoryEntityConfiguration : IEntityTypeConfiguration<PaymentStatusHistory>
{
    public void Configure(EntityTypeBuilder<PaymentStatusHistory> builder)
    {
        builder.Property(c => c.Value).IsRequired();
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.Note).IsRequired(false);
    }
}
