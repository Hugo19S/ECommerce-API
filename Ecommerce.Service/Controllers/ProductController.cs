using AutoMapper;
using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Application.Products.Commands.DeleteProduct;
using Ecommerce.Application.Products.Commands.UpdateProduct;
using Ecommerce.Application.Products.Queries.GetProduct;
using Ecommerce.Application.Products.Queries.GetProducts;
using Ecommerce.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class ProductController(ISender sender, IMapper mapper) : ApiController
{
    [HttpGet()]
    public async Task<ActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var productsOr = await sender.Send(new GetProductsCommand(), cancellationToken);
        return productsOr.Match(Ok, Problem);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult> GetProduct(Guid productId, CancellationToken cancellationToken)
    {
        var productOr = await sender.Send(new GetProductCommand(productId), cancellationToken);
        return productOr.Match(Ok, Problem);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] ProductCreateRequest request, 
                                                  CancellationToken cancellationToken)
    {
        var productCreated = await sender.Send(new CreateProductCommand(request), cancellationToken);

        return productCreated.Match(v => Ok(v), Problem);
    }

    [HttpPut("{productId:guid}")]
    public async Task<ActionResult> UpdateProduct(Guid productId,
                                            [FromBody] ProductUpdateRequest updateRequest,
                                            CancellationToken cancellationToken)
    {
        var productUpdatedOr = await sender.Send(new UpdateProductCommand(productId, updateRequest), cancellationToken);
        return productUpdatedOr.Match(v => Ok(v), Problem);
    }

    [HttpDelete("{productId:guid}")]
    public async Task<ActionResult> DeleteProduct(Guid productId, CancellationToken cancellationToken)
    {
        var productDeletedOr = await sender.Send(new DeleteProductCommand(productId), cancellationToken);

        return productDeletedOr.Match(v => Ok(v), Problem);
    }
}
