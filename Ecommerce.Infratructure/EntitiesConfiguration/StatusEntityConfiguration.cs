using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infratructure.EntitiesConfiguration;

public class StatusEntityConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(c => c.Type).IsRequired();
        builder.Property(c => c.Description).IsRequired(false);
    }
}
