using Ecommerce.Application.Carts.Commands.CreateProductCart;
using Ecommerce.Application.Carts.Commands.DeleteProductCart;
using Ecommerce.Application.Carts.Commands.UpdateProductCart;
using Ecommerce.Application.Carts.Queries.GetPrudctsCart;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class CartController(ISender sender) : ApiController
{
    [HttpGet("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetProductsCart(Guid userId, CancellationToken cancellationToken)
    {
        var productsCartOr = await sender.Send(new GetPrudctsCartQuery(userId), cancellationToken);
        return productsCartOr.Match(Ok, Problem);
    }

    [HttpPost("{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateProductCart(Guid userId,
                                                    [FromBody] CartProductRequest request,
                                                    CancellationToken cancellationToken)
    {
        var productCart = await sender.Send(new CreateProductCartCommand(userId,
                                                                         request.ProductId,
                                                                         request.Quantity), 
                                                                         cancellationToken);

        return productCart.Match(v => Created("", v), Problem);
    }

    [HttpPut("{cartId:guid}/{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateProductCart(Guid cartId,
                                             Guid productId,
                                             [FromBody] CartUpdateProductRequest cartUpdate,
                                             CancellationToken cancellationToken)
    {
        var productCartUpdatedOr = await sender.Send(new UpdateProductCartCommand(cartId,
                                                                                  productId,
                                                                                  cartUpdate.Quantity),
                                                                                  cancellationToken);
        return productCartUpdatedOr.Match(v => NoContent(), Problem);
    }

    [HttpDelete("{cartId:guid}/{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteProductCart(Guid cartId,
                                                      Guid productId,
                                                      CancellationToken cancellationToken)
    {
        var productCartDeletedOr = await sender.Send(new DeleteProductCartCommand(cartId,
                                                                                  productId),
                                                                                  cancellationToken);
        return productCartDeletedOr.Match(v => NoContent(), Problem);
    }
}
