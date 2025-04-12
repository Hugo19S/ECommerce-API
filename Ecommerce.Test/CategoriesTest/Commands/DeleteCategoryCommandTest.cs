using Ecommerce.Application.Categories.Commands.DeleteCategory;
using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.CategoriesTest.Commands;

public class DeleteCategoryCommandTest
{
    [Fact]
    public async void DeleteCategoryCommand_Return_Category_NotFound()
    {
        var mockUserRepository = new Mock<ICategoryRepository>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        DeleteCategoryCommand request = new(It.IsAny<Guid>());

        var deleteProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(deleteProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Category", request.CategoryId),
                     deleteProductCartResult.FirstError);
    }

    [Fact]
    public async void DeleteCategoryCommand_Return_Category_Deleted()
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "name",
            Description = "description",
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        };

        var mockUserRepository = new Mock<ICategoryRepository>();
        mockUserRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), CancellationToken.None))
                          .ReturnsAsync(category);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        DeleteCategoryCommand request = new(It.IsAny<Guid>());

        var deleteCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteCategotyResult.IsError);
        Assert.Equal(new Deleted(), deleteCategotyResult);
    }
}
