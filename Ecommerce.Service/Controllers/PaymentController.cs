using Ecommerce.Application.Payments.Commands.CreatePayment;
using Ecommerce.Application.Payments.Commands.CreatePaymentHistory;
using Ecommerce.Application.Payments.Queries.GetPayment;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
[Authorize(Roles = "Costumer")]
public class PaymentController(ISender sender) : ApiController
{
    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetPayment(Guid orderId, CancellationToken cancellationToken)
    {
        var payment = await sender.Send(new GetPaymentQuery(orderId), cancellationToken);

        return payment.Match(Ok, Problem);
    }

    [HttpPost("{orderId:guid}/{paymentMethodId:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreatePayment(Guid orderId,
                                            Guid paymentMethodId,
                                            [FromBody] PaymentRequest request,
                                            CancellationToken cancellationToken)
    {
        var paymentCreatedOr = await sender.Send(
            new CreatePaymentCommand(orderId, paymentMethodId, request.StatusId, 
            request.TotalPayable, request.TotalPaid, request.Note, request.InstallmentsNumber), 
            cancellationToken);

        return paymentCreatedOr.Match(v => Created("", v), Problem);
    }
    
    [HttpPost("{orderId:guid}")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreatePaymentHistory(Guid orderId,
                                            [FromBody] PaymentHistoryRequest request,
                                            CancellationToken cancellationToken)
    {
        var paymentCreatedOr = await sender.Send(
            new CreatePaymentHistoryCommand(orderId, request.PaymentId, request.StatusId, 
            request.TotalPaid, request.Note), 
            cancellationToken);

        return paymentCreatedOr.Match(v => Created("", v), Problem);
    }
}
