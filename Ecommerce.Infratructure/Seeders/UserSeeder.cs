﻿using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class UserSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.Parse("2587a6b7-0606-4355-9791-187993b185fb"), FirstName = "Lucas", LastName = "Silva", Email = "lucas.silva@example.com", Password = BCrypt.Net.BCrypt.HashPassword("LucasSilva"), PhoneNumber = "912345678", Address = "Rua das Flores, 120", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("26fba044-0f72-4eb2-a22f-1aa5133f3597"), FirstName = "Mariana", LastName = "Santos", Email = "mariana.santos@example.com", Password = BCrypt.Net.BCrypt.HashPassword("MarianaSantos"), PhoneNumber = "922345678", Address = "Avenida Paulista, 350", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("357766ff-0ea4-4e41-95e5-dc091d07dce6"), FirstName = "Ricardo", LastName = "Mendes", Email = "ricardo.mendes@example.com", Password = BCrypt.Net.BCrypt.HashPassword("RicardoMendes"), PhoneNumber = "932345678", Address = "Rua do Comércio, 45", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("457bce7f-2925-43b2-8ea1-9e16d214c4d4"), FirstName = "Fernanda", LastName = "Lima", Email = "fernanda.lima@example.com", Password = BCrypt.Net.BCrypt.HashPassword("FernandaLima"), PhoneNumber = "942345678", Address = "Praça Central, 90", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("470a4a17-033a-43ab-890f-5bfa2dc58c11"), FirstName = "Eduardo", LastName = "Almeida", Email = "eduardo.almeida@example.com", Password = BCrypt.Net.BCrypt.HashPassword("EduardoAlmeida"), PhoneNumber = "952345678", Address = "Travessa do Sol, 10", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("5d3a0719-ec82-47cf-9dc6-09742a90e699"), FirstName = "Ana", LastName = "Ferreira", Email = "ana.ferreira@example.com", Password = BCrypt.Net.BCrypt.HashPassword("AnaFerreira"), PhoneNumber = "962345678", Address = "Rua das Oliveiras, 200", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("75cd8061-acbc-4ebd-92a5-1f10513c49f6"), FirstName = "Carlos", LastName = "Pereira", Email = "carlos.pereira@example.com", Password = BCrypt.Net.BCrypt.HashPassword("CarlosPereira"), PhoneNumber = "972345678", Address = "Avenida Brasil, 410", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"), FirstName = "Beatriz", LastName = "Costa", Email = "beatriz.costa@example.com", Password = BCrypt.Net.BCrypt.HashPassword("BeatrizCosta"), PhoneNumber = "982345678", Address = "Rua Nova, 78", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"), FirstName = "Guilherme", LastName = "Rodrigues", Email = "guilherme.rodrigues@example.com", Password = BCrypt.Net.BCrypt.HashPassword("GuilhermeRodrigues"), PhoneNumber = "992345678", Address = "Vila do Mar, 35", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("c3943215-fcb6-40d3-a813-2f952b721f0d"), FirstName = "Sofia", LastName = "Martins", Email = "sofia.martins@example.com", Password = BCrypt.Net.BCrypt.HashPassword("SofiaMartins"), PhoneNumber = "1002345678", Address = "Rua do Lago, 88", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"), FirstName = "João", LastName = "Carvalho", Email = "joao.carvalho@example.com", Password = BCrypt.Net.BCrypt.HashPassword("JoãoCarvalho"), PhoneNumber = "1102345678", Address = "Estrada Velha, 101", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"), FirstName = "Camila", LastName = "Ribeiro", Email = "camila.ribeiro@example.com", Password = BCrypt.Net.BCrypt.HashPassword("CamilaRibeiro"), PhoneNumber = "1202345678", Address = "Avenida das Árvores, 75", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("d74473dd-4cfb-421b-9a97-8a48de482804"), FirstName = "Thiago", LastName = "Gomes", Email = "thiago.gomes@example.com", Password = BCrypt.Net.BCrypt.HashPassword("ThiagoGomes"), PhoneNumber = "1302345678", Address = "Rua Pequena, 30", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("e525b409-dfa7-4f7b-97df-d47c4f61bc99"), FirstName = "Larissa", LastName = "Duarte", Email = "larissa.duarte@example.com", Password = BCrypt.Net.BCrypt.HashPassword("LarissaDuarte"), PhoneNumber = "1402345678", Address = "Alameda Azul, 22", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") },
            new User { Id = Guid.Parse("f7a7da30-33db-454e-a2eb-574e9a834b59"), FirstName = "Pedro", LastName = "Nunes", Email = "pedro.nunes@example.com", Password = BCrypt.Net.BCrypt.HashPassword("PedroNunes"), PhoneNumber = "1502345678", Address = "Vila das Rosas, 55", CreatedAt = DateTimeOffset.Parse("2025-02-08T23:10:10.5590000+00:00") }
        );
    }
}
