using AutoMapper;
using Ecommerce.Application.Categories.Commands.CreateSeller;
using Ecommerce.Application.Categories.Commands.DeleteCategory;
using Ecommerce.Application.Categories.Commands.PatchCategory;
using Ecommerce.Application.Categories.Commands.UpdateCategory;
using Ecommerce.Application.Categories.Queries.GetCategories;
using Ecommerce.Application.Categories.Queries.GetCategory;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(Roles = "Manager")]
    public class CategoryController(ISender sender, IMapper mapper) : ApiController
    {
        [HttpGet]
        [Authorize(Roles = "Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var categoriesOr = await sender.Send(new GetCategoriesQuery(), cancellationToken);

            return categoriesOr.Match(v => Ok(mapper.Map<List<CategoryResponse>>(v)), Problem);
        }
        
        [HttpGet("{categoryId:guid}")]
        [Authorize(Roles = "Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var categoryOr = await sender.Send(new GetCategoryQuery(categoryId), cancellationToken);

            return categoryOr.Match(v => Ok(mapper.Map<CategoryResponse>(v)),
                                    Problem);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryRequest categoryRequest,
                                                       CancellationToken cancellationToken)
        {
            var categoryOr = await sender.Send(new CreateCategoryCommand(categoryRequest.Name,
                                                                         categoryRequest.Description), 
                                                                         cancellationToken);

            return categoryOr.Match(v => Created("", v), Problem);
        }
        
        [HttpPut("{categoryId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateCategory(Guid categoryId,
                                                 [FromBody] UpdateCategoryRequest request,
                                                 CancellationToken cancellationToken)
        {
            
            var categoryUpdatedOr = await sender.Send(new UpdateCategoryCommand(categoryId,
                                                                                request.Name,
                                                                                request.Description), 
                                                                                cancellationToken);
            return categoryUpdatedOr.Match(v => NoContent(), Problem);
        }

        [HttpPatch("{categoryId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PatchCategory(Guid categoryId,
                                                 [FromBody] JsonPatchDocument<Category> jsonPatch,
                                                 CancellationToken cancellationToken)
        {

            var categoryUpdatedOr = await sender.Send(new PatchCategoryCommand(categoryId,
                                                                                jsonPatch),
                                                                                cancellationToken);
            return categoryUpdatedOr.Match(v => NoContent(), Problem);
        }

        [HttpDelete("{categoryId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var categoryDeleteOr = await sender.Send(new DeleteCategoryCommand(categoryId), cancellationToken);
            return categoryDeleteOr.Match(v => NoContent(), Problem);
        }
    }
}
