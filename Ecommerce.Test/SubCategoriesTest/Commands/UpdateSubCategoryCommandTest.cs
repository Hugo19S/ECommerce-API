using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.SubCategories.Commands.UpdateSubCategory;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.SubCategoriesTest.Commands;

public class UpdateSubCategoryCommandTest
{
    [Fact]
    public async void UpdateSubCategoryCommand_Return_NotFound()
    {
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        UpdateSubCategoryCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

        var updateSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateSubCategoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("SubCategory", request.SubCategoryId), updateSubCategoryResult.FirstError);
    }
    
    [Fact]
    public async void UpdateSubCategoryCommand_Return_Conflict()
    {
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository.Setup(x => x.GetSubCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());
        
        mockSubCategoryRepository.Setup(x => x.GetSubCategoryByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        UpdateSubCategoryCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

        var updateSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateSubCategoryResult.IsError);
        Assert.Equal(DomainErrors.Conflict("SubCategory"), updateSubCategoryResult.FirstError);
    }
    
    [Fact]
    public async void UpdateSubCategoryCommand_Return_Updated()
    {
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository.Setup(x => x.GetSubCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        UpdateSubCategoryCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

        var updateSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(updateSubCategoryResult.IsError);
        Assert.Equal(new Updated(), updateSubCategoryResult);
    }
}
