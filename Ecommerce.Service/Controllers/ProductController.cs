using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Application.Products.Commands.DeleteProduct;
using Ecommerce.Application.Products.Commands.UpdateProduct;
using Ecommerce.Application.Products.Queries.GetProduct;
using Ecommerce.Application.Products.Queries.GetProducts;
using Ecommerce.Domain.Common;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class ProductController(ISender sender) : ApiController
{
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetProducts([FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        var productsOr = await sender.Send(new GetProductsCommand(request.Page, request.Limit), cancellationToken);
        return productsOr.Match(Ok, Problem);
    }

    [HttpGet("{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetProduct(Guid productId, CancellationToken cancellationToken)
    {
        var productOr = await sender.Send(new GetProductCommand(productId), cancellationToken);
        return productOr.Match(Ok, Problem);
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateProduct([FromBody] ProductCreateRequest request, 
                                                  CancellationToken cancellationToken)
    {
        var productCreated = await sender.Send(new CreateProductCommand(request), cancellationToken);

        return productCreated.Match(v => Created("", v), Problem);
    }

    [HttpPut("{productId:guid}")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateProduct(Guid productId,
                                            [FromBody] ProductUpdateRequest updateRequest,
                                            CancellationToken cancellationToken)
    {
        var productUpdatedOr = await sender.Send(new UpdateProductCommand(productId, updateRequest), cancellationToken);
        return productUpdatedOr.Match(v => NoContent(), Problem);
    }

    [HttpDelete("{productId:guid}")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteProduct(Guid productId, CancellationToken cancellationToken)
    {
        var productDeletedOr = await sender.Send(new DeleteProductCommand(productId), cancellationToken);

        return productDeletedOr.Match(v => NoContent(), Problem);
    }
}
