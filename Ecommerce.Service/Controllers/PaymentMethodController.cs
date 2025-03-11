using AutoMapper;
using Ecommerce.Application.PaymentMethods.Commands.CreatePaymentMethod;
using Ecommerce.Application.PaymentMethods.Commands.DeletePaymentMethod;
using Ecommerce.Application.PaymentMethods.Commands.UpdatePaymentMethod;
using Ecommerce.Application.PaymentMethods.Queries.GetPaymentMethod;
using Ecommerce.Application.PaymentMethods.Queries.GetPaymentMethods;
using Ecommerce.Service.Contracts;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class PaymentMethodController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost]
    public async Task<ActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodRequest paymentMethodRequest,
                                                  CancellationToken cancellationToken)
    {
        var createdPaymentMethodOr = await sender.Send(new CreatePaymentMethodCommand(paymentMethodRequest.Name), cancellationToken);

        return createdPaymentMethodOr.Match(v => Ok(v), Problem);
    }

    [HttpGet("{paymentMethodId:guid}")]
    public async Task<ActionResult> GetPaymentMethod(Guid paymentMethodId, CancellationToken cancellationToken)
    {
        var paymentMethodOr = await sender.Send(new GetPaymentMethodQuery(paymentMethodId), cancellationToken);

        return paymentMethodOr.Match(
            v => Ok(mapper.Map<PaymentMethodResponse>(v)),
            Problem);
    }

    [HttpGet]
    public async Task<ActionResult> GetPaymentMethods(CancellationToken cancellationToken)
    {
        var paymentMethodsOr = await sender.Send(new GetPaymentMethodsQuery(), cancellationToken);

        return paymentMethodsOr.Match(
            v => Ok(mapper.Map<List<PaymentMethodResponse>>(v)), 
            Problem);
    }

    [HttpDelete("{paymentMethodId:guid}")]
    public async Task<ActionResult> DeletePaymentMethod(Guid paymentMethodId, CancellationToken cancellationToken)
    {
        var deletedPaymentMethodOr = await sender.Send(new DeletePaymentMethodCommand(paymentMethodId), cancellationToken);

        return deletedPaymentMethodOr.Match(v => Ok(v), Problem);
    }

    [HttpPut("{paymentMethodId:guid}")]
    public async Task<ActionResult> UpdatePaymentMethod(Guid paymentMethodId,
                                                  [FromBody] UpdatePaymentMethodRequest paymentMethodRequest,
                                                  CancellationToken cancellationToken)
    {
        var updatedPaymentMethodOr = await sender.Send(new UpdatePaymentMethodCommand(paymentMethodId,
                                                                                paymentMethodRequest.Name), cancellationToken);
        return updatedPaymentMethodOr.Match(v => Ok(v), Problem);
    }
}
