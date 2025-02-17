using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Categories.Queries.GetCategory;

public record GetCategoryQuery(Guid CategoryId) : IRequest<ErrorOr<Domain.Entities.Category>>;

public class GetCategoryQueryHandler(ICategoryRepository repository)
    : IRequestHandler<GetCategoryQuery, ErrorOr<Domain.Entities.Category>>
{
    public async Task<ErrorOr<Domain.Entities.Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await repository.GetCategoryById(request.CategoryId, cancellationToken);

        if (category == null)
        {
            return Error.NotFound("Category.NotFound", $"Category with id {request.CategoryId} not found.");
        }

        return category;
    }
}
