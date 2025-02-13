using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class SubCategorySeerder
{
    public static void Seed(ModelBuilder modelBuilder, List<Category> categoryList)
    {
        modelBuilder.Entity<SubCategory>().HasData(
            // Eletrônicos
            new() { Id = Guid.Parse("04eb7890-d20f-47c9-b607-52f7484f8363"), CategoryId = Guid.Parse("89a470fd-ed2a-4b42-8049-f1e73ab9ed44"), Name = "Smartphones", Description = "Celulares e acessórios.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("08c88c0f-6461-403c-979a-5352dd267fe9"), CategoryId = Guid.Parse("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), Name = "Computadores", Description = "Notebooks, desktops e hardware.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("09e25da9-3a99-4b9f-8b04-01937bdf13c5"), CategoryId = Guid.Parse("c8baf944-31f8-4b42-b7a9-4360ed654ca0"), Name = "TVs e Áudio", Description = "Televisores, soundbars e fones de ouvido.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Moda
            new() { Id = Guid.Parse("115d77cf-c211-4986-a7d6-19c9e9360647"), CategoryId = Guid.Parse("551d8bfb-3328-4952-b2be-fa6991fae8d3"), Name = "Roupas Masculinas", Description = "Moda para homens.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("16cf3a50-1808-4958-b720-14dad2acedbb"), CategoryId = Guid.Parse("7e036bab-a332-435a-a382-2503ab9cd39c"), Name = "Roupas Femininas", Description = "Moda para mulheres.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("1e8deee9-51f3-4e85-a979-b3c3adc6fab6"), CategoryId = Guid.Parse("467010a7-7eea-431b-be34-7f6b47a65ddd"), Name = "Calçados", Description = "Sapatos, tênis e sandálias.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Beleza e Cuidados Pessoais
            new() { Id = Guid.Parse("2f878b61-309e-42b9-9087-187e98a2080d"), CategoryId = Guid.Parse("551d8bfb-3328-4952-b2be-fa6991fae8d3"), Name = "Maquiagem", Description = "Produtos de maquiagem.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("392c64ad-d7e9-44f3-9b41-3b8f3f1156f6"), CategoryId = Guid.Parse("714ebf08-6949-445b-b405-d7d1b133e23e"), Name = "Perfumes", Description = "Fragrâncias masculinas e femininas.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("419c3a3d-2421-489d-aa4a-77ab7d2d2157"), CategoryId = Guid.Parse("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), Name = "Cuidados com a Pele", Description = "Produtos para skincare.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Casa e Decoração
            new() { Id = Guid.Parse("4c7d53b8-ccaf-42b5-ac55-26e4c6eef3bd"), CategoryId = Guid.Parse("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), Name = "Móveis", Description = "Sofás, cadeiras e mesas.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("4d8f71fd-8f53-449d-873c-cc9ddc38fe96"), CategoryId = Guid.Parse("2d0b1e97-31bf-4969-90d9-554085ade54f"), Name = "Eletrodomésticos", Description = "Geladeiras, micro-ondas e fogões.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("4da56038-d824-4f4e-89dd-1c459bb11d05"), CategoryId = Guid.Parse("c17b8d60-433b-4418-997c-823dd771aaaa"), Name = "Decoração", Description = "Quadros, espelhos e tapetes.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Esportes e Lazer
            new() { Id = Guid.Parse("5c9ef436-b0c0-4c46-a0cd-91479d3f9c61"), CategoryId = Guid.Parse("551d8bfb-3328-4952-b2be-fa6991fae8d3"), Name = "Academia", Description = "Aparelhos e acessórios para exercícios.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("7b3c0948-8523-4512-8d0c-86a181b17fb1"), CategoryId = Guid.Parse("467010a7-7eea-431b-be34-7f6b47a65ddd"), Name = "Ciclismo", Description = "Bicicletas e acessórios.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("7bc8bc28-40c3-475e-86b0-e62125040484"), CategoryId = Guid.Parse("eccfb727-247b-40a5-87eb-24b28329923d"), Name = "Camping e Aventura", Description = "Barracas, mochilas e lanternas.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Automotivo
            new() { Id = Guid.Parse("91ad3d51-6ecf-4352-878b-545158ca4996"), CategoryId = Guid.Parse("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), Name = "Peças", Description = "Peças e acessórios para veículos.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("91ba1f55-2bfc-472b-aa8d-557bd2d2290b"), CategoryId = Guid.Parse("714ebf08-6949-445b-b405-d7d1b133e23e"), Name = "Som Automotivo", Description = "Aparelhos de som e multimídia.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("94a5e536-608b-4a70-b0d0-14ae0fb970cc"), CategoryId = Guid.Parse("038463d9-a7b7-4e30-9669-9962c1a01b18"), Name = "Lubrificantes", Description = "Óleos e fluídos automotivos.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Livros
            new() { Id = Guid.Parse("9f439954-a7ab-4231-bc38-cc0663b5ece4"), CategoryId = Guid.Parse("7e036bab-a332-435a-a382-2503ab9cd39c"), Name = "Ficção", Description = "Livros de romance, fantasia e drama.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("a0493846-8bd8-448b-8c9a-446cc043425a"), CategoryId = Guid.Parse("714ebf08-6949-445b-b405-d7d1b133e23e"), Name = "Didáticos", Description = "Livros acadêmicos e técnicos.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("a1faf56d-9c0b-4593-8f2d-769529351aec"), CategoryId = Guid.Parse("2d0b1e97-31bf-4969-90d9-554085ade54f"), Name = "Infantil", Description = "Livros para crianças.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Brinquedos e Games
            new() { Id = Guid.Parse("a2a77de5-c7ed-44fb-b4bd-03db99e31069"), CategoryId = Guid.Parse("467010a7-7eea-431b-be34-7f6b47a65ddd"), Name = "Bonecos", Description = "Brinquedos de ação e figuras.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("ae13d949-a4f1-4cb7-bd65-aaa1e0969bf3"), CategoryId = Guid.Parse("9d662433-2d41-4844-96b9-9fdf3b3d0589"), Name = "Videogames", Description = "Consoles e acessórios para jogos.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("af9f954d-260e-457d-ba28-2919d0adcfb6"), CategoryId = Guid.Parse("038463d9-a7b7-4e30-9669-9962c1a01b18"), Name = "Jogos de Tabuleiro", Description = "Jogos para toda a família.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Saúde e Bem-estar
            new() { Id = Guid.Parse("b1cbd0b6-a2d4-4e7f-bb12-693d864dc3d2"), CategoryId = Guid.Parse("038463d9-a7b7-4e30-9669-9962c1a01b18"), Name = "Vitaminas e Suplementos", Description = "Produtos para saúde e energia.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("b5570aa7-a9f8-48c7-ab72-c00b340ed98e"), CategoryId = Guid.Parse("814ea3c0-fac6-4e7a-a237-994c66cf8309"), Name = "Cuidados Médicos", Description = "Aparelhos de medição e primeiros socorros.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Pet Shop
            new() { Id = Guid.Parse("bad44db7-a993-41f0-ad7f-71468a4c4909"), CategoryId = Guid.Parse("7e036bab-a332-435a-a382-2503ab9cd39c"), Name = "Rações", Description = "Alimentos para cães e gatos.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("c9986069-d8be-4f46-8d65-eefc26aed70d"), CategoryId = Guid.Parse("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), Name = "Brinquedos", Description = "Brinquedos para animais de estimação.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Ferramentas e Construção
            new() { Id = Guid.Parse("cf50e5b5-ba94-4094-9f8a-f532e6dc052c"), CategoryId = Guid.Parse("89a470fd-ed2a-4b42-8049-f1e73ab9ed44"), Name = "Ferramentas Elétricas", Description = "Furadeiras, serras e mais.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Bebidas
            new() { Id = Guid.Parse("f0c040b4-2719-41f5-adf6-a8534b6159be"), CategoryId = Guid.Parse("814ea3c0-fac6-4e7a-a237-994c66cf8309"), Name = "Vinhos", Description = "Vinhos tintos, brancos e espumantes.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Informática
            new() { Id = Guid.Parse("fafec402-0328-4a34-9f42-9ed49cc7737c"), CategoryId = Guid.Parse("2d0b1e97-31bf-4969-90d9-554085ade54f"), Name = "Periféricos", Description = "Teclados, mouses e monitores.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            
            // Papelaria e Escritório
            new() { Id = Guid.Parse("fb29432b-9521-4f86-ae94-abdfde67476b"), CategoryId = Guid.Parse("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), Name = "Material Escolar", Description = "Cadernos, canetas e mochilas.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") }
        );
    }
}
