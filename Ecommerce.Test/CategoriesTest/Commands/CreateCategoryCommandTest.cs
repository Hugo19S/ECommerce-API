using Ecommerce.Application.Categories.Commands.CreateSeller;
using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.CategoriesTest.Commands;

public class CreateCategoryCommandTest
{
    [Fact]
    public async void CreateCategoryCommand_Return_Category_Conflict()
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
        mockUserRepository.Setup(x => x.GetCategoryByName(It.IsAny<string>(), CancellationToken.None))
                          .ReturnsAsync(category);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        CreateCategoryCommand request = new(It.IsAny<string>(), It.IsAny<string>());

        var createCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createCategotyResult.IsError);
        Assert.Equal(DomainErrors.Conflict("Category"),
                     createCategotyResult.FirstError);
    }
    
    [Fact]
    public async void CreateCategoryCommand_Return_Category_Created()
    {
        var mockUserRepository = new Mock<ICategoryRepository>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        CreateCategoryCommand request = new(It.IsAny<string>(), It.IsAny<string>());

        var createCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createCategotyResult.IsError);
        Assert.Equal(new Created(), createCategotyResult);
    }
}
