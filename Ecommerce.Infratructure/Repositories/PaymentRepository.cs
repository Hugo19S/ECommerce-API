using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class PaymentRepository(ECommerceDbContext dbContext) : IPaymentRepository
{
    public async Task AddPayment(Payment payment, CancellationToken cancellationToken)
    {
        await dbContext.Payment.AddAsync(payment, cancellationToken);
    }

    public async Task AddPaymentHistory(PaymentStatusHistory paymentHistory, CancellationToken cancellationToken)
    {
        await dbContext.PaymentStatusHistory.AddAsync(paymentHistory, cancellationToken);
    }

    public async Task<Payment?> GetPaymentById(Guid paymentId, CancellationToken cancellationToken)
    {
        return await dbContext.Payment
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == paymentId, cancellationToken);
    }
    
    public async Task<PaymentDto?> GetPaymentByOrder(Guid orderId, CancellationToken cancellationToken)
    {
        return await dbContext.Payment
                              .AsNoTracking()
                              .Where(x => x.OrderId == orderId)
                              .Select(p => new PaymentDto
                              {
                                  Id = p.Id,
                                  TotalPayable = p.TotalPayable,
                                  InstallmentsNumber = p.InstallmentsNumber,
                                  CreatedAt = p.CreatedAt,
                                  PaymentMethod = dbContext.PaymentMethod.AsNoTracking()
                                                         .First(x => x.Id == p.PaymentMethodId),
                                  PaymentStatusHistory = dbContext.PaymentStatusHistory.AsNoTracking()  
                                                                    .Where(x => x.PaymentId == p.Id)
                                                                    .ToList()
                              })
                              .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdatePayment(Guid paymentId, CancellationToken cancellationToken)
    {
        await dbContext.Payment
                       .Where(x => x.Id == paymentId)
                       .ExecuteUpdateAsync(p => p
                       .SetProperty(n => n.UpdatedAt, DateTimeOffset.UtcNow),
                       cancellationToken);
    }
}
