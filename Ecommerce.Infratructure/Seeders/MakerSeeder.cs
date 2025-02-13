using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class MakerSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Maker>().HasData(
            // Eletrônicos e Tecnologia
            new Maker { Id = Guid.Parse("081d772f-b2cb-4294-a696-c7abd6def254"), Name = "Apple", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("0de85792-6070-4b86-9160-0255ad272a9d"), Name = "Samsung", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("1436fb39-e357-4dbc-bcae-9ef5f2484f24"), Name = "Sony", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("1551ad97-d6ee-453a-a6a2-ebed64e8f193"), Name = "Microsoft", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("15a9e330-d5d9-425e-ac04-be14d46af7c0"), Name = "Dell", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("197d2342-230f-4a69-89e1-a9c9b353a12c"), Name = "HP", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("1d3ab503-366a-40ba-b7b7-8938c04a3ca1"), Name = "Lenovo", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("2125e0e9-c171-4986-ad10-220550c2d048"), Name = "Asus", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("23fae23f-686a-4713-9322-68f9b657e1ed"), Name = "Acer", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("380f06e1-f695-49b2-89ba-3a4ce9b60d55"), Name = "Razer", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("4587d91f-e8db-450b-b464-1e1e8553f8e1"), Name = "Xiaomi", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("4651d4f6-4fa1-4d7d-acaf-377eb4d2bce5"), Name = "Huawei", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("476b5d92-494c-4aaa-9ce1-9582a8c57f70"), Name = "OnePlus", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("4d88552f-1bee-4f3b-acf0-25f0ca3d560f"), Name = "Google", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("5aa01c32-da72-4872-a468-7a304d949398"), Name = "Amazon", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("5c6dda58-3546-4cea-bf53-a1ea52078898"), Name = "Logitech", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("5f5cc7d7-d617-456d-8a20-98c34106ca9b"), Name = "Intel", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("66cb463b-d653-449f-b122-4215f699b40b"), Name = "AMD", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("6c3e66b4-05d7-429e-b5dd-8ae3041ee0d7"), Name = "NVIDIA", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("6e4a564f-8ecd-4a5b-9f0e-e1fe266a347a"), Name = "Corsair", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Moda e Vestuário
            new Maker { Id = Guid.Parse("75948f5f-9043-44c0-8362-8ce71b6969b8"), Name = "Nike", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("776e10fc-8ddb-4ec4-b824-c4805ce84943"), Name = "Adidas", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("7d9bef7b-dd9c-4cdd-a67a-558335ea066c"), Name = "Puma", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("7e6c2acf-f643-476f-9285-112963b2493e"), Name = "Under Armour", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("7f0f16bd-5940-4f8a-92d5-d1e97d6b54ad"), Name = "Lacoste", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("801dd381-5c50-4f72-bfb2-39769c34880c"), Name = "Tommy Hilfiger", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("85514469-fe3f-46e0-a5c4-b1f9f2d29746"), Name = "Zara", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("8873441b-4d1b-44ae-9610-bdb6ade84b06"), Name = "H&M", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("8aac1b65-6525-482e-8a31-291bc8ec98e8"), Name = "Levi's", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("8f1c5306-a1fb-4b77-a5d5-7b0b8ec00c17"), Name = "Gucci", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("924e4b20-2153-447b-b167-287a4df7d85c"), Name = "Prada", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("9ae81c3b-11d4-4653-8a2f-48d0862fc48c"), Name = "Balenciaga", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("9b96367f-355b-484d-8d17-40030ceb01ac"), Name = "Versace", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("9d70eb42-538e-4a0c-aa61-a93894096421"), Name = "Dolce & Gabbana", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Beleza e Cosméticos
            new Maker { Id = Guid.Parse("9e1cd02f-de33-4a8b-80ea-384a3b28b069"), Name = "L'Oréal", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("a9153d71-1f5e-4987-9c9b-9e5e4277977b"), Name = "Maybelline", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("ac625e6e-ff0f-4194-8d79-2ee0450dfe22"), Name = "MAC Cosmetics", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("b203c2cb-8853-45ba-afb1-481719c7d992"), Name = "Dior", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("b2ce2952-cc4e-4281-9dc8-591030366dad"), Name = "Chanel", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("baadeac6-7fa3-4bf7-b473-473d9b2e4622"), Name = "Sephora", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("bb369028-5463-4d66-b24a-30b192019a83"), Name = "Estée Lauder", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("c184ccef-24b4-44fe-9c30-623c8d9ecbea"), Name = "Clinique", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Móveis e Decoração
            new Maker { Id = Guid.Parse("c396ba00-c243-45de-a53a-8ab0ae11c082"), Name = "IKEA", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("cbe5a9bd-a3b3-4126-9d17-9e342f5e5e1b"), Name = "Herman Miller", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("d3aa8c76-114b-464f-ac13-0440bcc222c4"), Name = "Tok&Stok", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("d3e93116-2e9a-42e0-9886-3f78d0575a9c"), Name = "Westwing", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("d65bac8a-ac9e-4b65-82b2-72379219c36d"), Name = "Casas Bahia", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Eletrodomésticos
            new Maker { Id = Guid.Parse("d6f4bd86-3214-4420-859a-f69b00e58164"), Name = "Bosch", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("d7c71163-e870-4b63-8ba6-8dbcf7c34d1f"), Name = "Brastemp", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("d9b56dc1-eb83-4b27-bc17-9aaf249ca254"), Name = "Electrolux", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("daae8177-3923-45b6-9f7c-5f037b5a573b"), Name = "Philips", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("db36a17f-8484-4ae2-b36f-400ac05ba762"), Name = "Panasonic", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("dc4ce02f-2127-4809-a717-024463411e21"), Name = "Samsung Home", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Automotivo
            new Maker { Id = Guid.Parse("e4fe3974-f9c7-43fd-9f20-1c342a63c1bc"), Name = "Volkswagen", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("e8bf1c3d-a396-4e02-9e20-7c87fe0e3d41"), Name = "Toyota", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("f0d79347-e419-4e72-9aa5-bacd54f3487a"), Name = "Honda", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("f87a2b1b-b79f-4389-b61a-ea585129bcc1"), Name = "Ford", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("f8fbb621-f6f5-43b2-8e4c-354572f909e8"), Name = "Chevrolet", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("fb4c2358-e346-4f5d-baba-67761cdf3dc7"), Name = "BMW", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new Maker { Id = Guid.Parse("fef7e8e9-54eb-4b1b-be20-cea01bf93b1b"), Name = "Mercedes-Benz", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") }
        );
    }
}
