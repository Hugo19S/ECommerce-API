using AutoMapper;
using Ecommerce.Application.Categories.Commands.CreateCategory;
using Ecommerce.Application.Categories.Commands.DeleteCategory;
using Ecommerce.Application.Categories.Commands.PatchCategory;
using Ecommerce.Application.Categories.Commands.UpdateCategory;
using Ecommerce.Application.Categories.Queries.GetCategories;
using Ecommerce.Application.Categories.Queries.GetCategory;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController(ISender sender, IMapper mapper) : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var categoriesOr = await sender.Send(new GetCategoriesQuery(), cancellationToken);

            return categoriesOr.Match(Ok, Problem);
        }
        
        [HttpGet("{categoryId:guid}")]
        public async Task<ActionResult> GetCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var categoryOr = await sender.Send(new GetCategoryQuery(categoryId), cancellationToken);

            return categoryOr.Match(Ok, Problem);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryRequest categoryRequest,
                                                       CancellationToken cancellationToken)
        {
            var categoryOr = await sender.Send(new CreateCategoryCommand(categoryRequest.Name,
                                                                         categoryRequest.Description), 
                                                                         cancellationToken);

            return categoryOr.Match(v => Ok(v), Problem);
        }
        
        [HttpPut("{categoryId:guid}")]
        public async Task<ActionResult> UpdateCategory(Guid categoryId,
                                                 [FromBody] UpdateCategoryRequest request,
                                                 CancellationToken cancellationToken)
        {
            
            var categoryUpdatedOr = await sender.Send(new UpdateCategoryCommand(categoryId,
                                                                                request.Name,
                                                                                request.Description), 
                                                                                cancellationToken);
            return categoryUpdatedOr.Match(v => Ok(v), Problem);
        }

        [HttpPatch("{categoryId:guid}")]
        public async Task<ActionResult> PatchCategory(Guid categoryId,
                                                 [FromBody] JsonPatchDocument<Category> jsonPatch,
                                                 CancellationToken cancellationToken)
        {

            var categoryUpdatedOr = await sender.Send(new PatchCategoryCommand(categoryId,
                                                                                jsonPatch),
                                                                                cancellationToken);
            return categoryUpdatedOr.Match(v => Ok(v), Problem);
        }

        [HttpDelete("{categoryId:guid}")]
        public async Task<ActionResult> DeleteCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var categoryDeleteOr = await sender.Send(new DeleteCategoryCommand(categoryId), cancellationToken);

            return categoryDeleteOr.Match(v => Ok(v), Problem);
        }
    }
}
