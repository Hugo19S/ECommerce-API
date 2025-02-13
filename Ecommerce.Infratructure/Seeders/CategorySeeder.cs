using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class CategorySeeder
{
    public static List<Category> Seed(ModelBuilder modelBuilder)
    {
        List<Category> categoryList =
        [
            new() { Id = Guid.Parse("038463d9-a7b7-4e30-9669-9962c1a01b18"), Name = "Eletrônicos", Description = "Dispositivos eletrônicos e acessórios.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), Name = "Moda", Description = "Roupas, calçados e acessórios.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), Name = "Beleza e Cuidados Pessoais", Description = "Produtos de beleza, perfumes e higiene pessoal.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("2d0b1e97-31bf-4969-90d9-554085ade54f"), Name = "Casa e Decoração", Description = "Móveis, utensílios domésticos e decoração.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("467010a7-7eea-431b-be34-7f6b47a65ddd"), Name = "Esportes e Lazer", Description = "Artigos esportivos, bicicletas e equipamentos de ginástica.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("551d8bfb-3328-4952-b2be-fa6991fae8d3"), Name = "Automotivo", Description = "Peças, acessórios e produtos automotivos.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("714ebf08-6949-445b-b405-d7d1b133e23e"), Name = "Livros", Description = "Livros, revistas e materiais de estudo.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("7e036bab-a332-435a-a382-2503ab9cd39c"), Name = "Brinquedos e Games", Description = "Brinquedos, jogos e videogames.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("814ea3c0-fac6-4e7a-a237-994c66cf8309"), Name = "Saúde e Bem-estar", Description = "Suplementos, produtos médicos e bem-estar.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("89a470fd-ed2a-4b42-8049-f1e73ab9ed44"), Name = "Pet Shop", Description = "Produtos para animais de estimação.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("9d662433-2d41-4844-96b9-9fdf3b3d0589"), Name = "Ferramentas e Construção", Description = "Ferramentas, materiais de construção e segurança.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("9eb5a466-0e78-47c2-ae8e-5957f71f601f"), Name = "Música e Entretenimento", Description = "Instrumentos musicais, filmes e shows.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("c17b8d60-433b-4418-997c-823dd771aaaa"), Name = "Bebidas", Description = "Vinhos, cervejas e destilados.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("c8baf944-31f8-4b42-b7a9-4360ed654ca0"), Name = "Informática", Description = "Computadores, hardware e softwares.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("cba476c6-63c2-4881-9cbe-caeb7e64877e"), Name = "Joias e Relógios", Description = "Relógios, joias e bijuterias.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("e87980c7-a781-4d8d-aa72-dc010336c06f"), Name = "Eletrodomésticos", Description = "Geladeiras, fogões, micro-ondas e mais.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("eccfb727-247b-40a5-87eb-24b28329923d"), Name = "Papelaria e Escritório", Description = "Material escolar e para escritório.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new() { Id = Guid.Parse("f3ecaecb-0ab7-46c6-a2a8-ed5c46f189e1"), Name = "Viagens e Turismo", Description = "Pacotes de viagem, passagens e hospedagem.", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") }
        ];


        modelBuilder.Entity<Category>().HasData(categoryList);
        return categoryList;
    }
}
