using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class UserRoleSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        List<UserRole> userRoles =
        [
            new UserRole {
                Id = Guid.Parse("1a2b3c4d-5e6f-7890-1234-56789abcdef0"),
                Name = "Admin",
                Description = "Has full access to the system and can manage other users."
            },

            new UserRole {
                Id = Guid.Parse("2b3c4d5e-6f78-9012-3456-789abcdef123"),
                Name = "Manager",
                Description = "Can manage product listings and view sales reports."
            },

            new UserRole {
                Id = Guid.Parse("3c4d5e6f-7890-1234-5678-9abcdef01234"),
                Name = "Customer",
                Description = "Can browse products, place orders, and track deliveries."
            },

            new UserRole {
                Id = Guid.Parse("4d5e6f78-9012-3456-789a-bcdef1234567"),
                Name = "Supplier",
                Description = "Can manage inventory and supply chain logistics."
            },

            new UserRole {
                Id = Guid.Parse("5e6f7890-1234-5678-9abc-def012345678"),
                Name = "Support",
                Description = "Handles customer support and resolves user issues."
            }
        ];

        modelBuilder.Entity<UserRole>().HasData(userRoles);
    }
}
