using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.SubCategories.Queries.GetSubCategory;

public record GetSubCategoryQuery(Guid SubCategoryId) : IRequest<ErrorOr<SubCategory>>;

public class GetSubCategoryQueryHandler(ISubCategoryRepository repository)
    : IRequestHandler<GetSubCategoryQuery, ErrorOr<SubCategory>>
{
    public async Task<ErrorOr<SubCategory>> Handle(GetSubCategoryQuery request, CancellationToken cancellationToken)
    {
        var subCategory = await repository.GetSubCategoryById(request.SubCategoryId, cancellationToken);

        if (subCategory == null)
        {
            return Error.NotFound("SubCategory.NotFound", $"SubCategory with id {request.SubCategoryId} not found.");
        }

        return subCategory;
    }
}
