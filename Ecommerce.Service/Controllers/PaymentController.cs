using Ecommerce.Application.Payments.Commands.CreatePayment;
using Ecommerce.Application.Payments.Commands.CreatePaymentHistory;
using Ecommerce.Application.Payments.Queries.GetPayment;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class PaymentController(ISender sender) : ApiController
{
    [HttpGet("{orderId:guid}")]
    public async Task<ActionResult> GetPayment(Guid orderId, CancellationToken cancellationToken)
    {
        var payment = await sender.Send(new GetPaymentCommand(orderId), cancellationToken);

        return payment.Match(Ok, Problem);
    }

    [HttpPost("{orderId:guid}/{paymentMethodId:guid}")]
    public async Task<ActionResult> CreatePayment(Guid orderId,
                                            Guid paymentMethodId,
                                            [FromBody] PaymentRequest request,
                                            CancellationToken cancellationToken)
    {
        var paymentCreatedOr = await sender.Send(
            new CreatePaymentCommand(orderId, paymentMethodId, request.StatusId, 
            request.TotalPayable, request.TotalPaid, request.Note, request.InstallmentsNumber), 
            cancellationToken);

        return paymentCreatedOr.Match(v => Ok(v), Problem);
    }
    
    [HttpPost("{orderId:guid}")]
    public async Task<ActionResult> CreatePaymentHistory(Guid orderId,
                                            [FromBody] PaymentHistoryRequest request,
                                            CancellationToken cancellationToken)
    {
        var paymentCreatedOr = await sender.Send(
            new CreatePaymentHistoryCommand(orderId, request.PaymentId, request.StatusId, 
            request.TotalPaid, request.Note), 
            cancellationToken);

        return paymentCreatedOr.Match(v => Ok(v), Problem);
    }
}
