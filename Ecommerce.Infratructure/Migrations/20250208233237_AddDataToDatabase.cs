using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("038463d9-a7b7-4e30-9669-9962c1a01b18"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dispositivos eletrônicos e acessórios.", "Eletrônicos", null },
                    { new Guid("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Roupas, calçados e acessórios.", "Moda", null },
                    { new Guid("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Produtos de beleza, perfumes e higiene pessoal.", "Beleza e Cuidados Pessoais", null },
                    { new Guid("2d0b1e97-31bf-4969-90d9-554085ade54f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Móveis, utensílios domésticos e decoração.", "Casa e Decoração", null },
                    { new Guid("467010a7-7eea-431b-be34-7f6b47a65ddd"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Artigos esportivos, bicicletas e equipamentos de ginástica.", "Esportes e Lazer", null },
                    { new Guid("551d8bfb-3328-4952-b2be-fa6991fae8d3"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Peças, acessórios e produtos automotivos.", "Automotivo", null },
                    { new Guid("714ebf08-6949-445b-b405-d7d1b133e23e"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Livros, revistas e materiais de estudo.", "Livros", null },
                    { new Guid("7e036bab-a332-435a-a382-2503ab9cd39c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brinquedos, jogos e videogames.", "Brinquedos e Games", null },
                    { new Guid("814ea3c0-fac6-4e7a-a237-994c66cf8309"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Suplementos, produtos médicos e bem-estar.", "Saúde e Bem-estar", null },
                    { new Guid("89a470fd-ed2a-4b42-8049-f1e73ab9ed44"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Produtos para animais de estimação.", "Pet Shop", null },
                    { new Guid("9d662433-2d41-4844-96b9-9fdf3b3d0589"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Ferramentas, materiais de construção e segurança.", "Ferramentas e Construção", null },
                    { new Guid("9eb5a466-0e78-47c2-ae8e-5957f71f601f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Instrumentos musicais, filmes e shows.", "Música e Entretenimento", null },
                    { new Guid("c17b8d60-433b-4418-997c-823dd771aaaa"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Vinhos, cervejas e destilados.", "Bebidas", null },
                    { new Guid("c8baf944-31f8-4b42-b7a9-4360ed654ca0"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Computadores, hardware e softwares.", "Informática", null },
                    { new Guid("cba476c6-63c2-4881-9cbe-caeb7e64877e"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Relógios, joias e bijuterias.", "Joias e Relógios", null },
                    { new Guid("e87980c7-a781-4d8d-aa72-dc010336c06f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Geladeiras, fogões, micro-ondas e mais.", "Eletrodomésticos", null },
                    { new Guid("eccfb727-247b-40a5-87eb-24b28329923d"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Material escolar e para escritório.", "Papelaria e Escritório", null },
                    { new Guid("f3ecaecb-0ab7-46c6-a2a8-ed5c46f189e1"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Pacotes de viagem, passagens e hospedagem.", "Viagens e Turismo", null }
                });

            migrationBuilder.InsertData(
                table: "Maker",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("081d772f-b2cb-4294-a696-c7abd6def254"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Apple", null },
                    { new Guid("0de85792-6070-4b86-9160-0255ad272a9d"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Samsung", null },
                    { new Guid("1436fb39-e357-4dbc-bcae-9ef5f2484f24"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sony", null },
                    { new Guid("1551ad97-d6ee-453a-a6a2-ebed64e8f193"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Microsoft", null },
                    { new Guid("15a9e330-d5d9-425e-ac04-be14d46af7c0"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dell", null },
                    { new Guid("197d2342-230f-4a69-89e1-a9c9b353a12c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "HP", null },
                    { new Guid("1d3ab503-366a-40ba-b7b7-8938c04a3ca1"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Lenovo", null },
                    { new Guid("2125e0e9-c171-4986-ad10-220550c2d048"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Asus", null },
                    { new Guid("23fae23f-686a-4713-9322-68f9b657e1ed"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Acer", null },
                    { new Guid("380f06e1-f695-49b2-89ba-3a4ce9b60d55"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Razer", null },
                    { new Guid("4587d91f-e8db-450b-b464-1e1e8553f8e1"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Xiaomi", null },
                    { new Guid("4651d4f6-4fa1-4d7d-acaf-377eb4d2bce5"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Huawei", null },
                    { new Guid("476b5d92-494c-4aaa-9ce1-9582a8c57f70"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "OnePlus", null },
                    { new Guid("4d88552f-1bee-4f3b-acf0-25f0ca3d560f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Google", null },
                    { new Guid("5aa01c32-da72-4872-a468-7a304d949398"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Amazon", null },
                    { new Guid("5c6dda58-3546-4cea-bf53-a1ea52078898"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Logitech", null },
                    { new Guid("5f5cc7d7-d617-456d-8a20-98c34106ca9b"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Intel", null },
                    { new Guid("66cb463b-d653-449f-b122-4215f699b40b"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AMD", null },
                    { new Guid("6c3e66b4-05d7-429e-b5dd-8ae3041ee0d7"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NVIDIA", null },
                    { new Guid("6e4a564f-8ecd-4a5b-9f0e-e1fe266a347a"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Corsair", null },
                    { new Guid("75948f5f-9043-44c0-8362-8ce71b6969b8"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nike", null },
                    { new Guid("776e10fc-8ddb-4ec4-b824-c4805ce84943"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Adidas", null },
                    { new Guid("7d9bef7b-dd9c-4cdd-a67a-558335ea066c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Puma", null },
                    { new Guid("7e6c2acf-f643-476f-9285-112963b2493e"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Under Armour", null },
                    { new Guid("7f0f16bd-5940-4f8a-92d5-d1e97d6b54ad"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Lacoste", null },
                    { new Guid("801dd381-5c50-4f72-bfb2-39769c34880c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tommy Hilfiger", null },
                    { new Guid("85514469-fe3f-46e0-a5c4-b1f9f2d29746"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Zara", null },
                    { new Guid("8873441b-4d1b-44ae-9610-bdb6ade84b06"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "H&M", null },
                    { new Guid("8aac1b65-6525-482e-8a31-291bc8ec98e8"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Levi's", null },
                    { new Guid("8f1c5306-a1fb-4b77-a5d5-7b0b8ec00c17"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Gucci", null },
                    { new Guid("924e4b20-2153-447b-b167-287a4df7d85c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Prada", null },
                    { new Guid("9ae81c3b-11d4-4653-8a2f-48d0862fc48c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Balenciaga", null },
                    { new Guid("9b96367f-355b-484d-8d17-40030ceb01ac"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Versace", null },
                    { new Guid("9d70eb42-538e-4a0c-aa61-a93894096421"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dolce & Gabbana", null },
                    { new Guid("9e1cd02f-de33-4a8b-80ea-384a3b28b069"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "L'Oréal", null },
                    { new Guid("a9153d71-1f5e-4987-9c9b-9e5e4277977b"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Maybelline", null },
                    { new Guid("ac625e6e-ff0f-4194-8d79-2ee0450dfe22"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MAC Cosmetics", null },
                    { new Guid("b203c2cb-8853-45ba-afb1-481719c7d992"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dior", null },
                    { new Guid("b2ce2952-cc4e-4281-9dc8-591030366dad"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Chanel", null },
                    { new Guid("baadeac6-7fa3-4bf7-b473-473d9b2e4622"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sephora", null },
                    { new Guid("bb369028-5463-4d66-b24a-30b192019a83"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Estée Lauder", null },
                    { new Guid("c184ccef-24b4-44fe-9c30-623c8d9ecbea"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Clinique", null },
                    { new Guid("c396ba00-c243-45de-a53a-8ab0ae11c082"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "IKEA", null },
                    { new Guid("cbe5a9bd-a3b3-4126-9d17-9e342f5e5e1b"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Herman Miller", null },
                    { new Guid("d3aa8c76-114b-464f-ac13-0440bcc222c4"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tok&Stok", null },
                    { new Guid("d3e93116-2e9a-42e0-9886-3f78d0575a9c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Westwing", null },
                    { new Guid("d65bac8a-ac9e-4b65-82b2-72379219c36d"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Casas Bahia", null },
                    { new Guid("d6f4bd86-3214-4420-859a-f69b00e58164"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bosch", null },
                    { new Guid("d7c71163-e870-4b63-8ba6-8dbcf7c34d1f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brastemp", null },
                    { new Guid("d9b56dc1-eb83-4b27-bc17-9aaf249ca254"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Electrolux", null },
                    { new Guid("daae8177-3923-45b6-9f7c-5f037b5a573b"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Philips", null },
                    { new Guid("db36a17f-8484-4ae2-b36f-400ac05ba762"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Panasonic", null },
                    { new Guid("dc4ce02f-2127-4809-a717-024463411e21"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Samsung Home", null },
                    { new Guid("e4fe3974-f9c7-43fd-9f20-1c342a63c1bc"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Volkswagen", null },
                    { new Guid("e8bf1c3d-a396-4e02-9e20-7c87fe0e3d41"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Toyota", null },
                    { new Guid("f0d79347-e419-4e72-9aa5-bacd54f3487a"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Honda", null },
                    { new Guid("f87a2b1b-b79f-4389-b61a-ea585129bcc1"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Ford", null },
                    { new Guid("f8fbb621-f6f5-43b2-8e4c-354572f909e8"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Chevrolet", null },
                    { new Guid("fb4c2358-e346-4f5d-baba-67761cdf3dc7"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BMW", null },
                    { new Guid("fef7e8e9-54eb-4b1b-be20-cea01bf93b1b"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mercedes-Benz", null }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("0aebae07-efce-4c70-a765-c6e1a8445b90"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cartão de crédito" },
                    { new Guid("3a604480-cc31-4c09-b34c-888849c8ba56"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cartão de débito" },
                    { new Guid("abc3e010-4215-4027-8817-6dd73487d709"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MB WAY" },
                    { new Guid("be437362-39a3-4da3-926f-50e4745e2759"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Referência Multibanco" },
                    { new Guid("f727dd8e-fdbd-436f-b950-c22c251c2513"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PayPal" }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("0225b611-6107-45ae-8792-a91264cc171a"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tech Solutions" },
                    { new Guid("18679883-6207-4a03-8910-0ea9917f861d"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Fashion Hub" },
                    { new Guid("29ed19de-65bf-4eb9-99ab-0c9654b5b22c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Gamer Store" },
                    { new Guid("4a8b6274-01ad-44fa-bf78-64c3a73feac8"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Home & Decor" },
                    { new Guid("5672e789-06ed-4033-bd6f-66968fa09801"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Pet Lovers" },
                    { new Guid("7798bbf7-2c63-4344-b49e-0c8d590cafbe"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Supermarket Express" },
                    { new Guid("7cb6b742-5121-42d6-b091-5d6a8ef3c7a8"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Eco Friendly Market" },
                    { new Guid("82a5f157-ca2d-43cc-921b-a24661b30964"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Smart Gadgets" },
                    { new Guid("99c1fcbd-ae0d-4934-a264-7df5d4ef0d1a"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Fitness World" },
                    { new Guid("a126cee8-a14e-4f30-a937-6c78a0c29e20"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Luxury Watches" },
                    { new Guid("a2757788-f4fe-4395-ac0d-f02ed7f89da9"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Office Supplies" },
                    { new Guid("ab6e152d-aea3-455e-806b-2832f15532f6"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Outdoor Adventure" },
                    { new Guid("b0147209-86c0-46ca-8f63-a2a484f3b620"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Car Accessories" },
                    { new Guid("b139337f-7aa0-4951-b692-479d523b3f61"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Book Haven" },
                    { new Guid("bb90f150-62d9-4f65-ac81-544368c2b39b"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Beauty Essentials" },
                    { new Guid("c7fd9fba-c0e1-4c2f-b9e3-bd6b4a8ab8f0"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Baby & Kids" },
                    { new Guid("c9816f8e-5e78-4197-b383-6c9b43a02f85"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Handmade Crafts" },
                    { new Guid("d9dd984f-f96f-49c3-a848-cc6a7ebb9162"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sports Gear" },
                    { new Guid("ec9b11d8-ecc6-4d29-847c-833a5ae04ebf"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Automotive Parts" },
                    { new Guid("f084b67f-2ad4-46bd-91e1-e39abd8f61b3"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Vintage Finds" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("148a42ad-e148-43c9-8174-ea0436461bde"), "Pagamento em análise.", "Em Processamento", "Pagamento" },
                    { new Guid("48416049-e247-4687-aa00-bffd4c8266b4"), "Pagamento não realizado.", "Falhado", "Pagamento" },
                    { new Guid("581c7e3e-7595-41f9-8345-3f53b4c8d070"), "A aguardar pagamento.", "Pendente", "Pagamento" },
                    { new Guid("7a9c935d-b6aa-4c56-b8cc-6bb4e44e14d0"), "Pagamento concluído com sucesso.", "Pago", "Pagamento" },
                    { new Guid("82c32d44-a380-4a57-bb37-212e59816562"), "Pagamento devolvido ao cliente.", "Reembolsado", "Pagamento" },
                    { new Guid("9b2c498a-04e1-41bd-bf5c-d0e0208f88e2"), "Pagamento cancelado pelo cliente.", "Cancelado", "Pagamento" },
                    { new Guid("a78bf64a-a2c0-44cc-a8c4-7d4d44dcd39f"), "Pedido aceite pela loja.", "Confirmado", "Pedido" },
                    { new Guid("bc4430c7-d401-416d-a394-0e93afcd6258"), "Pedido foi cancelado.", "Cancelado", "Pedido" },
                    { new Guid("c50c6e4b-dde6-4477-bba5-ff2acc90968d"), "Pedido devolvido pelo cliente.", "Devolvido", "Pedido" },
                    { new Guid("ca236c21-a82c-4f55-9d4c-36e6a7dbda7f"), "Pedido entregue ao cliente.", "Entregue", "Pedido" },
                    { new Guid("ca6fd996-d245-40ce-8415-e47adabf05d4"), "Pedido a ser preparado.", "Em Processamento", "Pedido" },
                    { new Guid("dee7068f-954b-4f4a-8d93-a9da05a478d4"), "Pedido recebido, a aguardar ação.", "Pendente", "Pedido" },
                    { new Guid("f07ef34d-a0d9-4c60-b530-2dcdbd021f65"), "Pedido enviado para entrega.", "Enviado", "Pedido" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "AlternativeAddress", "CreatedAt", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2587a6b7-0606-4355-9791-187993b185fb"), "Rua das Flores, 120", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "lucas.silva@example.com", "Lucas", "Silva", "$2a$11$azUFOkohBXKH3dH27.yEUeG7..W.EuYBk48W8T/UMRc3DKfjhcqCC", "912345678", "Admin", null },
                    { new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"), "Avenida Paulista, 350", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "mariana.santos@example.com", "Mariana", "Santos", "$2a$11$30mkmc1/.tUNlz21ME1iCOpffyu.PHaQmsNzpZ2vkK5CwKeTcnKAW", "922345678", "Admin", null },
                    { new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"), "Rua do Comércio, 45", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ricardo.mendes@example.com", "Ricardo", "Mendes", "$2a$11$7oVASZrOCcJecgpTrVBJkej3.RaUQkT9tbc8KxznkLW2EI4Cq3p/i", "932345678", "Admin", null },
                    { new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"), "Praça Central, 90", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "fernanda.lima@example.com", "Fernanda", "Lima", "$2a$11$vLvWz4.66V/bwgGnMRBWMuY.HzIbT/AK3IFOpVRtCrlHkZx/vg.Qe", "942345678", "Admin", null },
                    { new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"), "Travessa do Sol, 10", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "eduardo.almeida@example.com", "Eduardo", "Almeida", "$2a$11$7Np8MiBEdH9yP9npyFRjze3R4Y5Jnl2hkuJRRsAR5EYZp2e7ZBkri", "952345678", "Admin", null },
                    { new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"), "Rua das Oliveiras, 200", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ana.ferreira@example.com", "Ana", "Ferreira", "$2a$11$wKnrrTHD2bA1lWyL0HQbue3g9nl48JdBj2vs12/fqvHyGFrRexBoe", "962345678", "User", null },
                    { new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"), "Avenida Brasil, 410", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "carlos.pereira@example.com", "Carlos", "Pereira", "$2a$11$NSKLqwEdM50lfmW4kISbZuuuGHf/n61giQJAvoiA5uXsOCPv22Yde", "972345678", "User", null },
                    { new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"), "Rua Nova, 78", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "beatriz.costa@example.com", "Beatriz", "Costa", "$2a$11$9Y/pCOVlh13YMJUl2ygRYO.6nj7LS0F5uZWWeVxScBhvqlOuwEMBe", "982345678", "User", null },
                    { new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"), "Vila do Mar, 35", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "guilherme.rodrigues@example.com", "Guilherme", "Rodrigues", "$2a$11$EMV888OPGHENgRcrc1E0ReKlaZYa.BTNTkA9n99NaW13d0OdrBSii", "992345678", "User", null },
                    { new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"), "Rua do Lago, 88", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "sofia.martins@example.com", "Sofia", "Martins", "$2a$11$m1DbR/aw7LWPg51EHLMnb.Su88Ms9lyjOD.CCRZi6gXA.1kmRyyXG", "1002345678", "User", null },
                    { new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"), "Estrada Velha, 101", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "joao.carvalho@example.com", "João", "Carvalho", "$2a$11$BU.HZG23bgP7t8d9DYd0YuakwtafliSwTzcmxwSpLrxNhCV03uP5y", "1102345678", "User", null },
                    { new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"), "Avenida das Árvores, 75", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "camila.ribeiro@example.com", "Camila", "Ribeiro", "$2a$11$TYNl7ZydUTRM3PBzzUZYP.4TJAoHzn8vMh2meMKZYiIcTFhtfyHh6", "1202345678", "User", null },
                    { new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"), "Rua Pequena, 30", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "thiago.gomes@example.com", "Thiago", "Gomes", "$2a$11$by1CTOiNt83P87IIZ19bTe6RheXETVfdrvkTzQaefyLlO2k1hpj8e", "1302345678", "User", null },
                    { new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"), "Alameda Azul, 22", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "larissa.duarte@example.com", "Larissa", "Duarte", "$2a$11$gjveauG2YXz61Cxi54iPLev.kIBJVAGUcOXrKb1gCMQ5uAxqtQso6", "1402345678", "User", null },
                    { new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"), "Vila das Rosas, 55", null, new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "pedro.nunes@example.com", "Pedro", "Nunes", "$2a$11$Rj2rsbzJibvpwglPQsqEhu6kRlwKDsvXRW22R.0UiA7ThirWZQR3W", "1502345678", "User", null }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04eb7890-d20f-47c9-b607-52f7484f8363"), new Guid("89a470fd-ed2a-4b42-8049-f1e73ab9ed44"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Celulares e acessórios.", "Smartphones", null },
                    { new Guid("08c88c0f-6461-403c-979a-5352dd267fe9"), new Guid("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Notebooks, desktops e hardware.", "Computadores", null },
                    { new Guid("09e25da9-3a99-4b9f-8b04-01937bdf13c5"), new Guid("c8baf944-31f8-4b42-b7a9-4360ed654ca0"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Televisores, soundbars e fones de ouvido.", "TVs e Áudio", null },
                    { new Guid("115d77cf-c211-4986-a7d6-19c9e9360647"), new Guid("551d8bfb-3328-4952-b2be-fa6991fae8d3"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Moda para homens.", "Roupas Masculinas", null },
                    { new Guid("16cf3a50-1808-4958-b720-14dad2acedbb"), new Guid("7e036bab-a332-435a-a382-2503ab9cd39c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Moda para mulheres.", "Roupas Femininas", null },
                    { new Guid("1e8deee9-51f3-4e85-a979-b3c3adc6fab6"), new Guid("467010a7-7eea-431b-be34-7f6b47a65ddd"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sapatos, tênis e sandálias.", "Calçados", null },
                    { new Guid("2f878b61-309e-42b9-9087-187e98a2080d"), new Guid("551d8bfb-3328-4952-b2be-fa6991fae8d3"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Produtos de maquiagem.", "Maquiagem", null },
                    { new Guid("392c64ad-d7e9-44f3-9b41-3b8f3f1156f6"), new Guid("714ebf08-6949-445b-b405-d7d1b133e23e"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Fragrâncias masculinas e femininas.", "Perfumes", null },
                    { new Guid("419c3a3d-2421-489d-aa4a-77ab7d2d2157"), new Guid("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Produtos para skincare.", "Cuidados com a Pele", null },
                    { new Guid("4c7d53b8-ccaf-42b5-ac55-26e4c6eef3bd"), new Guid("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sofás, cadeiras e mesas.", "Móveis", null },
                    { new Guid("4d8f71fd-8f53-449d-873c-cc9ddc38fe96"), new Guid("2d0b1e97-31bf-4969-90d9-554085ade54f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Geladeiras, micro-ondas e fogões.", "Eletrodomésticos", null },
                    { new Guid("4da56038-d824-4f4e-89dd-1c459bb11d05"), new Guid("c17b8d60-433b-4418-997c-823dd771aaaa"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Quadros, espelhos e tapetes.", "Decoração", null },
                    { new Guid("5c9ef436-b0c0-4c46-a0cd-91479d3f9c61"), new Guid("551d8bfb-3328-4952-b2be-fa6991fae8d3"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Aparelhos e acessórios para exercícios.", "Academia", null },
                    { new Guid("7b3c0948-8523-4512-8d0c-86a181b17fb1"), new Guid("467010a7-7eea-431b-be34-7f6b47a65ddd"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bicicletas e acessórios.", "Ciclismo", null },
                    { new Guid("7bc8bc28-40c3-475e-86b0-e62125040484"), new Guid("eccfb727-247b-40a5-87eb-24b28329923d"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Barracas, mochilas e lanternas.", "Camping e Aventura", null },
                    { new Guid("91ad3d51-6ecf-4352-878b-545158ca4996"), new Guid("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Peças e acessórios para veículos.", "Peças", null },
                    { new Guid("91ba1f55-2bfc-472b-aa8d-557bd2d2290b"), new Guid("714ebf08-6949-445b-b405-d7d1b133e23e"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Aparelhos de som e multimídia.", "Som Automotivo", null },
                    { new Guid("94a5e536-608b-4a70-b0d0-14ae0fb970cc"), new Guid("038463d9-a7b7-4e30-9669-9962c1a01b18"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Óleos e fluídos automotivos.", "Lubrificantes", null },
                    { new Guid("9f439954-a7ab-4231-bc38-cc0663b5ece4"), new Guid("7e036bab-a332-435a-a382-2503ab9cd39c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Livros de romance, fantasia e drama.", "Ficção", null },
                    { new Guid("a0493846-8bd8-448b-8c9a-446cc043425a"), new Guid("714ebf08-6949-445b-b405-d7d1b133e23e"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Livros acadêmicos e técnicos.", "Didáticos", null },
                    { new Guid("a1faf56d-9c0b-4593-8f2d-769529351aec"), new Guid("2d0b1e97-31bf-4969-90d9-554085ade54f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Livros para crianças.", "Infantil", null },
                    { new Guid("a2a77de5-c7ed-44fb-b4bd-03db99e31069"), new Guid("467010a7-7eea-431b-be34-7f6b47a65ddd"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brinquedos de ação e figuras.", "Bonecos", null },
                    { new Guid("ae13d949-a4f1-4cb7-bd65-aaa1e0969bf3"), new Guid("9d662433-2d41-4844-96b9-9fdf3b3d0589"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Consoles e acessórios para jogos.", "Videogames", null },
                    { new Guid("af9f954d-260e-457d-ba28-2919d0adcfb6"), new Guid("038463d9-a7b7-4e30-9669-9962c1a01b18"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Jogos para toda a família.", "Jogos de Tabuleiro", null },
                    { new Guid("b1cbd0b6-a2d4-4e7f-bb12-693d864dc3d2"), new Guid("038463d9-a7b7-4e30-9669-9962c1a01b18"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Produtos para saúde e energia.", "Vitaminas e Suplementos", null },
                    { new Guid("b5570aa7-a9f8-48c7-ab72-c00b340ed98e"), new Guid("814ea3c0-fac6-4e7a-a237-994c66cf8309"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Aparelhos de medição e primeiros socorros.", "Cuidados Médicos", null },
                    { new Guid("bad44db7-a993-41f0-ad7f-71468a4c4909"), new Guid("7e036bab-a332-435a-a382-2503ab9cd39c"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Alimentos para cães e gatos.", "Rações", null },
                    { new Guid("c9986069-d8be-4f46-8d65-eefc26aed70d"), new Guid("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brinquedos para animais de estimação.", "Brinquedos", null },
                    { new Guid("cf50e5b5-ba94-4094-9f8a-f532e6dc052c"), new Guid("89a470fd-ed2a-4b42-8049-f1e73ab9ed44"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Furadeiras, serras e mais.", "Ferramentas Elétricas", null },
                    { new Guid("f0c040b4-2719-41f5-adf6-a8534b6159be"), new Guid("814ea3c0-fac6-4e7a-a237-994c66cf8309"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Vinhos tintos, brancos e espumantes.", "Vinhos", null },
                    { new Guid("fafec402-0328-4a34-9f42-9ed49cc7737c"), new Guid("2d0b1e97-31bf-4969-90d9-554085ade54f"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Teclados, mouses e monitores.", "Periféricos", null },
                    { new Guid("fb29432b-9521-4f86-ae94-abdfde67476b"), new Guid("1f22bf92-2a35-4cf8-b22a-502598f6bf56"), new DateTimeOffset(new DateTime(2025, 2, 8, 23, 10, 10, 559, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cadernos, canetas e mochilas.", "Material Escolar", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9eb5a466-0e78-47c2-ae8e-5957f71f601f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("cba476c6-63c2-4881-9cbe-caeb7e64877e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e87980c7-a781-4d8d-aa72-dc010336c06f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3ecaecb-0ab7-46c6-a2a8-ed5c46f189e1"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("081d772f-b2cb-4294-a696-c7abd6def254"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("0de85792-6070-4b86-9160-0255ad272a9d"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("1436fb39-e357-4dbc-bcae-9ef5f2484f24"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("1551ad97-d6ee-453a-a6a2-ebed64e8f193"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("15a9e330-d5d9-425e-ac04-be14d46af7c0"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("197d2342-230f-4a69-89e1-a9c9b353a12c"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("1d3ab503-366a-40ba-b7b7-8938c04a3ca1"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("2125e0e9-c171-4986-ad10-220550c2d048"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("23fae23f-686a-4713-9322-68f9b657e1ed"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("380f06e1-f695-49b2-89ba-3a4ce9b60d55"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("4587d91f-e8db-450b-b464-1e1e8553f8e1"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("4651d4f6-4fa1-4d7d-acaf-377eb4d2bce5"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("476b5d92-494c-4aaa-9ce1-9582a8c57f70"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("4d88552f-1bee-4f3b-acf0-25f0ca3d560f"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("5aa01c32-da72-4872-a468-7a304d949398"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("5c6dda58-3546-4cea-bf53-a1ea52078898"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("5f5cc7d7-d617-456d-8a20-98c34106ca9b"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("66cb463b-d653-449f-b122-4215f699b40b"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("6c3e66b4-05d7-429e-b5dd-8ae3041ee0d7"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("6e4a564f-8ecd-4a5b-9f0e-e1fe266a347a"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("75948f5f-9043-44c0-8362-8ce71b6969b8"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("776e10fc-8ddb-4ec4-b824-c4805ce84943"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("7d9bef7b-dd9c-4cdd-a67a-558335ea066c"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("7e6c2acf-f643-476f-9285-112963b2493e"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("7f0f16bd-5940-4f8a-92d5-d1e97d6b54ad"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("801dd381-5c50-4f72-bfb2-39769c34880c"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("85514469-fe3f-46e0-a5c4-b1f9f2d29746"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("8873441b-4d1b-44ae-9610-bdb6ade84b06"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("8aac1b65-6525-482e-8a31-291bc8ec98e8"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("8f1c5306-a1fb-4b77-a5d5-7b0b8ec00c17"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("924e4b20-2153-447b-b167-287a4df7d85c"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("9ae81c3b-11d4-4653-8a2f-48d0862fc48c"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("9b96367f-355b-484d-8d17-40030ceb01ac"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("9d70eb42-538e-4a0c-aa61-a93894096421"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("9e1cd02f-de33-4a8b-80ea-384a3b28b069"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("a9153d71-1f5e-4987-9c9b-9e5e4277977b"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("ac625e6e-ff0f-4194-8d79-2ee0450dfe22"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("b203c2cb-8853-45ba-afb1-481719c7d992"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("b2ce2952-cc4e-4281-9dc8-591030366dad"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("baadeac6-7fa3-4bf7-b473-473d9b2e4622"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("bb369028-5463-4d66-b24a-30b192019a83"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("c184ccef-24b4-44fe-9c30-623c8d9ecbea"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("c396ba00-c243-45de-a53a-8ab0ae11c082"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("cbe5a9bd-a3b3-4126-9d17-9e342f5e5e1b"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("d3aa8c76-114b-464f-ac13-0440bcc222c4"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("d3e93116-2e9a-42e0-9886-3f78d0575a9c"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("d65bac8a-ac9e-4b65-82b2-72379219c36d"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("d6f4bd86-3214-4420-859a-f69b00e58164"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("d7c71163-e870-4b63-8ba6-8dbcf7c34d1f"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("d9b56dc1-eb83-4b27-bc17-9aaf249ca254"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("daae8177-3923-45b6-9f7c-5f037b5a573b"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("db36a17f-8484-4ae2-b36f-400ac05ba762"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("dc4ce02f-2127-4809-a717-024463411e21"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("e4fe3974-f9c7-43fd-9f20-1c342a63c1bc"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("e8bf1c3d-a396-4e02-9e20-7c87fe0e3d41"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("f0d79347-e419-4e72-9aa5-bacd54f3487a"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("f87a2b1b-b79f-4389-b61a-ea585129bcc1"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("f8fbb621-f6f5-43b2-8e4c-354572f909e8"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("fb4c2358-e346-4f5d-baba-67761cdf3dc7"));

            migrationBuilder.DeleteData(
                table: "Maker",
                keyColumn: "Id",
                keyValue: new Guid("fef7e8e9-54eb-4b1b-be20-cea01bf93b1b"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("0aebae07-efce-4c70-a765-c6e1a8445b90"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("3a604480-cc31-4c09-b34c-888849c8ba56"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("abc3e010-4215-4027-8817-6dd73487d709"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("be437362-39a3-4da3-926f-50e4745e2759"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("f727dd8e-fdbd-436f-b950-c22c251c2513"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("0225b611-6107-45ae-8792-a91264cc171a"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("18679883-6207-4a03-8910-0ea9917f861d"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("29ed19de-65bf-4eb9-99ab-0c9654b5b22c"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("4a8b6274-01ad-44fa-bf78-64c3a73feac8"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("5672e789-06ed-4033-bd6f-66968fa09801"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("7798bbf7-2c63-4344-b49e-0c8d590cafbe"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("7cb6b742-5121-42d6-b091-5d6a8ef3c7a8"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("82a5f157-ca2d-43cc-921b-a24661b30964"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("99c1fcbd-ae0d-4934-a264-7df5d4ef0d1a"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("a126cee8-a14e-4f30-a937-6c78a0c29e20"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("a2757788-f4fe-4395-ac0d-f02ed7f89da9"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("ab6e152d-aea3-455e-806b-2832f15532f6"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("b0147209-86c0-46ca-8f63-a2a484f3b620"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("b139337f-7aa0-4951-b692-479d523b3f61"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("bb90f150-62d9-4f65-ac81-544368c2b39b"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("c7fd9fba-c0e1-4c2f-b9e3-bd6b4a8ab8f0"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("c9816f8e-5e78-4197-b383-6c9b43a02f85"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("d9dd984f-f96f-49c3-a848-cc6a7ebb9162"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("ec9b11d8-ecc6-4d29-847c-833a5ae04ebf"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("f084b67f-2ad4-46bd-91e1-e39abd8f61b3"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("148a42ad-e148-43c9-8174-ea0436461bde"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("48416049-e247-4687-aa00-bffd4c8266b4"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("581c7e3e-7595-41f9-8345-3f53b4c8d070"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("7a9c935d-b6aa-4c56-b8cc-6bb4e44e14d0"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("82c32d44-a380-4a57-bb37-212e59816562"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("9b2c498a-04e1-41bd-bf5c-d0e0208f88e2"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("a78bf64a-a2c0-44cc-a8c4-7d4d44dcd39f"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("bc4430c7-d401-416d-a394-0e93afcd6258"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("c50c6e4b-dde6-4477-bba5-ff2acc90968d"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("ca236c21-a82c-4f55-9d4c-36e6a7dbda7f"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("ca6fd996-d245-40ce-8415-e47adabf05d4"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("dee7068f-954b-4f4a-8d93-a9da05a478d4"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: new Guid("f07ef34d-a0d9-4c60-b530-2dcdbd021f65"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("04eb7890-d20f-47c9-b607-52f7484f8363"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("08c88c0f-6461-403c-979a-5352dd267fe9"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("09e25da9-3a99-4b9f-8b04-01937bdf13c5"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("115d77cf-c211-4986-a7d6-19c9e9360647"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("16cf3a50-1808-4958-b720-14dad2acedbb"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("1e8deee9-51f3-4e85-a979-b3c3adc6fab6"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("2f878b61-309e-42b9-9087-187e98a2080d"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("392c64ad-d7e9-44f3-9b41-3b8f3f1156f6"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("419c3a3d-2421-489d-aa4a-77ab7d2d2157"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("4c7d53b8-ccaf-42b5-ac55-26e4c6eef3bd"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("4d8f71fd-8f53-449d-873c-cc9ddc38fe96"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("4da56038-d824-4f4e-89dd-1c459bb11d05"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("5c9ef436-b0c0-4c46-a0cd-91479d3f9c61"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("7b3c0948-8523-4512-8d0c-86a181b17fb1"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("7bc8bc28-40c3-475e-86b0-e62125040484"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("91ad3d51-6ecf-4352-878b-545158ca4996"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("91ba1f55-2bfc-472b-aa8d-557bd2d2290b"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("94a5e536-608b-4a70-b0d0-14ae0fb970cc"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("9f439954-a7ab-4231-bc38-cc0663b5ece4"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("a0493846-8bd8-448b-8c9a-446cc043425a"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("a1faf56d-9c0b-4593-8f2d-769529351aec"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("a2a77de5-c7ed-44fb-b4bd-03db99e31069"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("ae13d949-a4f1-4cb7-bd65-aaa1e0969bf3"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("af9f954d-260e-457d-ba28-2919d0adcfb6"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("b1cbd0b6-a2d4-4e7f-bb12-693d864dc3d2"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("b5570aa7-a9f8-48c7-ab72-c00b340ed98e"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("bad44db7-a993-41f0-ad7f-71468a4c4909"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("c9986069-d8be-4f46-8d65-eefc26aed70d"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("cf50e5b5-ba94-4094-9f8a-f532e6dc052c"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("f0c040b4-2719-41f5-adf6-a8534b6159be"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("fafec402-0328-4a34-9f42-9ed49cc7737c"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("fb29432b-9521-4f86-ae94-abdfde67476b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("038463d9-a7b7-4e30-9669-9962c1a01b18"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1f22bf92-2a35-4cf8-b22a-502598f6bf56"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2b3fd91f-51a5-4134-a22c-c37eb4d03ffe"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2d0b1e97-31bf-4969-90d9-554085ade54f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("467010a7-7eea-431b-be34-7f6b47a65ddd"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("551d8bfb-3328-4952-b2be-fa6991fae8d3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("714ebf08-6949-445b-b405-d7d1b133e23e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7e036bab-a332-435a-a382-2503ab9cd39c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("814ea3c0-fac6-4e7a-a237-994c66cf8309"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("89a470fd-ed2a-4b42-8049-f1e73ab9ed44"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9d662433-2d41-4844-96b9-9fdf3b3d0589"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c17b8d60-433b-4418-997c-823dd771aaaa"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c8baf944-31f8-4b42-b7a9-4360ed654ca0"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("eccfb727-247b-40a5-87eb-24b28329923d"));
        }
    }
}
