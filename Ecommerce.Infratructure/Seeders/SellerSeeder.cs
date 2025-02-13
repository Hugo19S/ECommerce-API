using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class SellerSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Seller>().HasData(
            new Seller { Id = Guid.Parse("0225b611-6107-45ae-8792-a91264cc171a"), Name = "Tech Solutions", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("18679883-6207-4a03-8910-0ea9917f861d"), Name = "Fashion Hub", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("29ed19de-65bf-4eb9-99ab-0c9654b5b22c"), Name = "Gamer Store", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("4a8b6274-01ad-44fa-bf78-64c3a73feac8"), Name = "Home & Decor", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("5672e789-06ed-4033-bd6f-66968fa09801"), Name = "Pet Lovers", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("7798bbf7-2c63-4344-b49e-0c8d590cafbe"), Name = "Supermarket Express", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("7cb6b742-5121-42d6-b091-5d6a8ef3c7a8"), Name = "Eco Friendly Market", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("82a5f157-ca2d-43cc-921b-a24661b30964"), Name = "Smart Gadgets", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("99c1fcbd-ae0d-4934-a264-7df5d4ef0d1a"), Name = "Fitness World", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("a126cee8-a14e-4f30-a937-6c78a0c29e20"), Name = "Luxury Watches", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("a2757788-f4fe-4395-ac0d-f02ed7f89da9"), Name = "Office Supplies", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("ab6e152d-aea3-455e-806b-2832f15532f6"), Name = "Outdoor Adventure", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("b0147209-86c0-46ca-8f63-a2a484f3b620"), Name = "Car Accessories", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("b139337f-7aa0-4951-b692-479d523b3f61"), Name = "Book Haven", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("bb90f150-62d9-4f65-ac81-544368c2b39b"), Name = "Beauty Essentials", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("c7fd9fba-c0e1-4c2f-b9e3-bd6b4a8ab8f0"), Name = "Baby & Kids", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("c9816f8e-5e78-4197-b383-6c9b43a02f85"), Name = "Handmade Crafts", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("d9dd984f-f96f-49c3-a848-cc6a7ebb9162"), Name = "Sports Gear", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("ec9b11d8-ecc6-4d29-847c-833a5ae04ebf"), Name = "Automotive Parts", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Seller { Id = Guid.Parse("f084b67f-2ad4-46bd-91e1-e39abd8f61b3"), Name = "Vintage Finds", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") }
        );
    }
}
