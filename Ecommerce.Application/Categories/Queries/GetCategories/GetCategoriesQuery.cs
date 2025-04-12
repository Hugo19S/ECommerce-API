using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Categories.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<ErrorOr<List<Category>>>;

public class GetCategoriesQueryHandler(ICategoryRepository repository)
    : IRequestHandler<GetCategoriesQuery, ErrorOr<List<Category>>>
{
    public async Task<ErrorOr<List<Domain.Entities.Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllCategories(cancellationToken);
    }
}
