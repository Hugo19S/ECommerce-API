using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.SubCategories.Commands.DeleteSubCategory;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.SubCategoriesTest.Commands;

public class DeleteSubCategoryCommandTest
{
    [Fact]
    public async void DeleteSubCategoryCommand_Return_NotFound()
    {
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        DeleteSubCategoryCommand request = new(It.IsAny<Guid>());

        var deleteSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(deleteSubCategoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("SubCategory", request.SubCategoryId), deleteSubCategoryResult.FirstError);
    }

    [Fact]
    public async void DeleteSubCategoryCommand_Return_Deleted()
    {
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository.Setup(x => x.GetSubCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteSubCategoryCommandHandler handler = new(
            mockSubCategoryRepository.Object,
            mockUnitOfWorkRepository.Object);

        DeleteSubCategoryCommand request = new(It.IsAny<Guid>());

        var deleteSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteSubCategoryResult.IsError);
        Assert.Equal(new Deleted(), deleteSubCategoryResult);
    }
}
