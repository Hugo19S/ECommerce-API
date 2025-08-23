using AutoMapper;
using Ecommerce.Application.Sellers.Commands.CreateSeller;
using Ecommerce.Application.Sellers.Commands.DeleteSeller;
using Ecommerce.Application.Sellers.Commands.UpdateSeller;
using Ecommerce.Application.Sellers.Queries.GetSeller;
using Ecommerce.Application.Sellers.Queries.GetSellers;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(Roles = "Manager")]
    public class SellerController(ISender sender, IMapper mapper) : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetSellers(CancellationToken cancellationToken)
        {
            var sellersOr = await sender.Send(new GetSellersQuery(), cancellationToken);

            return sellersOr.Match(v => Ok(mapper.Map<List<SellerResponse>>(v)), Problem);
        }
        
        [HttpGet("{sellerId:guid}")]
        [Authorize(Roles = "Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetSeller(Guid sellerId, CancellationToken cancellationToken)
        {
            var sellerOr = await sender.Send(new GetSellerQuery(sellerId), cancellationToken);

            return sellerOr.Match(v => Ok(mapper.Map<SellerResponse>(v)), Problem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateSeller([FromBody] CreateSellerRequest sellerRequest,
                                               CancellationToken cancellationToken)
        {
            var sellerCreatedOr = await sender.Send(new CreateSellerCommand(sellerRequest.Name), cancellationToken);
            return sellerCreatedOr.Match(v => Created("", v), Problem);
        }

        [HttpPut("{sellerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateSeller(Guid sellerId,
                                               [FromBody] UpdateSellerRequest sellerRequest,
                                               CancellationToken cancellationToken)
        {
            var sellerDeletedOr = await sender.Send(new UpdateSellerCommand(sellerId, sellerRequest.Name), cancellationToken);

            return sellerDeletedOr.Match(v => NoContent(), Problem);
        }

        [HttpDelete("{sellerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSeller(Guid sellerId, CancellationToken cancellationToken)
        {
            var sellerDeletedOr = await sender.Send(new DeleteSellerCommand(sellerId), cancellationToken);

            return sellerDeletedOr.Match(v => NoContent(), Problem);
        }
    }
}
