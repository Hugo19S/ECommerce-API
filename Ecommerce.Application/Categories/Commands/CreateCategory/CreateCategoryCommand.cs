using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name, string? Description) : IRequest<ErrorOr<Created>>;

public class CreateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryExist = await repository.GetCategoryByName(request.Name, cancellationToken);

        if (categoryExist != null)
        {
            return Error.Conflict("Category.Conflict", "There's already a category with the same name!");
        }

        var newCategory = new Domain.Entities.Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await repository.AddCategoty(newCategory, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
