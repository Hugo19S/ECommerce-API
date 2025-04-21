using AutoMapper;
using Ecommerce.Application.SubCategories.Commands.CreateSubCategory;
using Ecommerce.Application.SubCategories.Commands.DeleteSubCategory;
using Ecommerce.Application.SubCategories.Commands.UpdateSubCategory;
using Ecommerce.Application.SubCategories.Queries.GetSubCategories;
using Ecommerce.Application.SubCategories.Queries.GetSubCategory;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("/api/[controller]")]
[Authorize(Roles = "Manager")]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public class SubCategoryController(ISender sender, IMapper mapper) : ApiController
{
    [HttpGet("{categoryId:guid}/subcategories")]
    [Authorize(Roles = "Costumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetSubCategoriesByCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        var subCategoriesOr = await sender.Send(new GetSubCategoriesQuery(categoryId), cancellationToken);

        return subCategoriesOr.Match(v => Ok(mapper.Map<List<SubCategoryResponse>>(v)),
                                     Problem);
    }
    
    [HttpGet("{subCategoryId:guid}")]
    [Authorize(Roles = "Costumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetSubCategory(Guid subCategoryId, CancellationToken cancellationToken)
    {
        var subCategoryOr = await sender.Send(new GetSubCategoryQuery(subCategoryId), cancellationToken);

        return subCategoryOr.Match(v => Ok(mapper.Map<SubCategoryResponse>(v)), Problem);
    }
    
    [HttpPost("{categoryId:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateSubCategory(Guid categoryId,
                                                [FromBody] CreateSubCategoryRequest request,
                                                CancellationToken cancellationToken)
    {
        var subCategoryCreatedOr = await sender.Send(new CreateSubCategoryCommand(request.Name,
                                                                            request.Description,
                                                                            categoryId), cancellationToken);

        return subCategoryCreatedOr.Match(v => Created("", v), Problem);
    }
    
    [HttpPut("{subCategoryId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> UpdateSubCategory(Guid subCategoryId,
                                                [FromBody] UpdateSubCategoryRequest subCategoryRequest, 
                                                CancellationToken cancellationToken)
    {
        var subCategoryOr = await sender.Send(new UpdateSubCategoryCommand(subCategoryId,
                                                                           subCategoryRequest.Name,
                                                                           subCategoryRequest.Description), 
                                                                           cancellationToken);
        return subCategoryOr.Match(v => NoContent(), Problem);
    }

    [HttpDelete("{subCategoryId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteSubCategory(Guid subCategoryId, CancellationToken cancellationToken)
    {
        var subCategoryDeletedOr = await sender.Send(new DeleteSubCategoryCommand(subCategoryId), cancellationToken);

        return subCategoryDeletedOr.Match(v => NoContent(), Problem);
    }
}
