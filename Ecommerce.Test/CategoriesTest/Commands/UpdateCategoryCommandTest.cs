using Ecommerce.Application.Categories.Commands.UpdateCategory;
using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.CategoriesTest.Commands;

public class UpdateCategoryCommandTest
{
    [Fact]
    public async void UpdateCategoryCommand_Return_Category_Conflict()
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Test",
            CreatedAt = DateTimeOffset.Now,
        };

        var mockUserRepository = new Mock<ICategoryRepository>();
        mockUserRepository.Setup(x => x.GetCategoryByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateCategoryCommandHandler handler = new(mockUserRepository.Object, mockUnitOfWork.Object);

        UpdateCategoryCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

        var updateCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateCategotyResult.IsError);
        Assert.Equal(DomainErrors.Conflict("Category"), updateCategotyResult.FirstError);
    }
    
    [Fact]
    public async void UpdateCategoryCommand_Return_Category_NotFound()
    {
        var mockUserRepository = new Mock<ICategoryRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        UpdateCategoryCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

        var updateCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateCategotyResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Category", request.CategoryId), updateCategotyResult.FirstError);
    }
    
    [Fact]
    public async void UpdateCategoryCommand_Return_Category_Updated()
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Test",
            CreatedAt = DateTimeOffset.Now,
        };

        var mockUserRepository = new Mock<ICategoryRepository>();
        mockUserRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        UpdateCategoryCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

        var updateCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(updateCategotyResult.IsError);
        Assert.Equal(new Updated(), updateCategotyResult);
    }
}
