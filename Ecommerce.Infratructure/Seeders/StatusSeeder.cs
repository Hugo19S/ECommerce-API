using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Seeders;

public static class StatusSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = Guid.Parse("148a42ad-e148-43c9-8174-ea0436461bde"), Name = "Em Processamento", Type = "Pagamento", Description = "Pagamento em análise." },
            new Status { Id = Guid.Parse("48416049-e247-4687-aa00-bffd4c8266b4"), Name = "Falhado", Type = "Pagamento", Description = "Pagamento não realizado." },
            new Status { Id = Guid.Parse("581c7e3e-7595-41f9-8345-3f53b4c8d070"), Name = "Pendente", Type = "Pagamento", Description = "A aguardar pagamento." },
            new Status { Id = Guid.Parse("7a9c935d-b6aa-4c56-b8cc-6bb4e44e14d0"), Name = "Pago", Type = "Pagamento", Description = "Pagamento concluído com sucesso." },
            new Status { Id = Guid.Parse("82c32d44-a380-4a57-bb37-212e59816562"), Name = "Reembolsado", Type = "Pagamento", Description = "Pagamento devolvido ao cliente." },
            new Status { Id = Guid.Parse("9b2c498a-04e1-41bd-bf5c-d0e0208f88e2"), Name = "Cancelado", Type = "Pagamento", Description = "Pagamento cancelado pelo cliente." },
            new Status { Id = Guid.Parse("a78bf64a-a2c0-44cc-a8c4-7d4d44dcd39f"), Name = "Confirmado", Type = "Pedido", Description = "Pedido aceite pela loja." },
            new Status { Id = Guid.Parse("bc4430c7-d401-416d-a394-0e93afcd6258"), Name = "Cancelado", Type = "Pedido", Description = "Pedido foi cancelado." },
            new Status { Id = Guid.Parse("c50c6e4b-dde6-4477-bba5-ff2acc90968d"), Name = "Devolvido", Type = "Pedido", Description = "Pedido devolvido pelo cliente." },
            new Status { Id = Guid.Parse("ca236c21-a82c-4f55-9d4c-36e6a7dbda7f"), Name = "Entregue", Type = "Pedido", Description = "Pedido entregue ao cliente." },
            new Status { Id = Guid.Parse("ca6fd996-d245-40ce-8415-e47adabf05d4"), Name = "Em Processamento", Type = "Pedido", Description = "Pedido a ser preparado." },
            new Status { Id = Guid.Parse("dee7068f-954b-4f4a-8d93-a9da05a478d4"), Name = "Pendente", Type = "Pedido", Description = "Pedido recebido, a aguardar ação." },
            new Status { Id = Guid.Parse("f07ef34d-a0d9-4c60-b530-2dcdbd021f65"), Name = "Enviado", Type = "Pedido", Description = "Pedido enviado para entrega." }
        );
    }
}
