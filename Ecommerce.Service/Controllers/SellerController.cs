using AutoMapper;
using Ecommerce.Application.Sellers.Commands.CreateSeller;
using Ecommerce.Application.Sellers.Commands.DeleteSeller;
using Ecommerce.Application.Sellers.Commands.UpdateSeller;
using Ecommerce.Application.Sellers.Queries.GetSeller;
using Ecommerce.Application.Sellers.Queries.GetSellers;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers
{
    [Route("/api/[controller]")]
    public class SellerController(ISender sender, IMapper mapper) : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetSellers(CancellationToken cancellationToken)
        {
            var sellersOr = await sender.Send(new GetSellersCommand(), cancellationToken);

            return sellersOr.Match(v => Ok(mapper.Map<List<SellerResponse>>(v)), Problem);
        }
        
        [HttpGet("{sellerId:guid}")]
        public async Task<ActionResult> GetSeller(Guid sellerId, CancellationToken cancellationToken)
        {
            var sellerOr = await sender.Send(new GetSellerCommand(sellerId), cancellationToken);

            return sellerOr.Match(v => Ok(mapper.Map<SellerResponse>(v)), Problem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSeller([FromBody] CreateSellerRequest sellerRequest,
                                               CancellationToken cancellationToken)
        {
            var sellerCreatedOr = await sender.Send(new CreateSellerCommand(sellerRequest.Name), cancellationToken);

            return sellerCreatedOr.Match(v => Ok(v), Problem);
        }

        [HttpPut("{sellerId}")]
        public async Task<ActionResult> UpdateSeller(Guid sellerId,
                                               [FromBody] UpdateSellerRequest sellerRequest,
                                               CancellationToken cancellationToken)
        {
            var sellerDeletedOr = await sender.Send(new UpdateSellerCommand(sellerId, sellerRequest.Name), cancellationToken);

            return sellerDeletedOr.Match(v => Ok(v), Problem);
        }

        [HttpDelete("{sellerId}")]
        public async Task<ActionResult> DeleteSeller(Guid sellerId, CancellationToken cancellationToken)
        {
            var sellerDeletedOr = await sender.Send(new DeleteSellerCommand(sellerId), cancellationToken);

            return sellerDeletedOr.Match(v => Ok(v), Problem);
        }
    }
}
