using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class PaymentMethodSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentMethod>().HasData(
            new PaymentMethod { Id = Guid.Parse("0aebae07-efce-4c70-a765-c6e1a8445b90"), Name = "Cartão de crédito", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new PaymentMethod { Id = Guid.Parse("3a604480-cc31-4c09-b34c-888849c8ba56"), Name = "Cartão de débito", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new PaymentMethod { Id = Guid.Parse("abc3e010-4215-4027-8817-6dd73487d709"), Name = "MB WAY", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new PaymentMethod { Id = Guid.Parse("be437362-39a3-4da3-926f-50e4745e2759"), Name = "Referência Multibanco", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new PaymentMethod { Id = Guid.Parse("f727dd8e-fdbd-436f-b950-c22c251c2513"), Name = "PayPal", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") }
        );
    }
}
