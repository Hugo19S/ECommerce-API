using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.SubCategories.Commands.CreateSubCategory;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.SubCategoriesTest.Commands;

public class CreateSubCategoryCommandTest
{
    [Fact]
    public async void CreateSubCategoryCommand_Return_NotFound()
    {
        var mockCategoryRepositoryRepository = new Mock<ICategoryRepository>();
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object, 
            mockCategoryRepositoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateSubCategoryCommand request = new(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>());

        var createSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createSubCategoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Category", request.CategoryId), createSubCategoryResult.FirstError);
    }
    
    [Fact]
    public async void CreateSubCategoryCommand_Return_Conflict()
    {
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Category());

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository.Setup(x => x.GetSubCategoryByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object, 
            mockCategoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateSubCategoryCommand request = new(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>());

        var createSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createSubCategoryResult.IsError);
        Assert.Equal(DomainErrors.Conflict("SubCategory"), createSubCategoryResult.FirstError);
    }

    [Fact]
    public async void CreateSubCategoryCommand_Return_Created()
    {
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Category());

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository.Setup(x => x.AddSubCategory(new SubCategory(), It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object, 
            mockCategoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateSubCategoryCommand request = new(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>());

        var createSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createSubCategoryResult.IsError);
        Assert.Equal(new Created(), createSubCategoryResult);
    }
}
