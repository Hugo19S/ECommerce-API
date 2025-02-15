using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class PaymentMethodRepository(ECommerceDbContext dbContext) : IPaymentMethodRepository
{
    public async Task AddPaymentMethod(PaymentMethod paymentMethod, CancellationToken cancellationToken)
    {
        await dbContext.PaymentMethod.AddAsync(paymentMethod, cancellationToken);
    }

    public async Task DeletePaymentMethod(Guid paymentMethodId, CancellationToken cancellationToken)
    {
        await dbContext.PaymentMethod.Where(x => x.Id == paymentMethodId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<PaymentMethod?>> GetAllPaymentMethod(CancellationToken cancellationToken)
    {
        return await dbContext.PaymentMethod.ToListAsync(cancellationToken);
    }

    public async Task<PaymentMethod?> GetPaymentMethodById(Guid paymentMethodId, CancellationToken cancellationToken)
    {
        return await dbContext.PaymentMethod.FirstOrDefaultAsync(x => x.Id ==  paymentMethodId, cancellationToken);
    }

    public async Task<PaymentMethod?> GetPaymentMethodByName(string name, CancellationToken cancellationToken)
    {
        return await dbContext.PaymentMethod.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }

    public async Task UpdatePaymentMethod(Guid paymentMethodId, string name, CancellationToken cancellationToken)
    {
        await dbContext.PaymentMethod.Where(x => x.Id == paymentMethodId)
                                     .ExecuteUpdateAsync(p => p
                                     .SetProperty(c => c.Name, name), 
                                     cancellationToken);
    }
}
