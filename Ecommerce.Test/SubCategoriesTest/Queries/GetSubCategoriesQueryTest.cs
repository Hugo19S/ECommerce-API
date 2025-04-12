using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.SubCategories.Queries.GetSubCategories;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.SubCategoriesTest.Queries;

public class GetSubCategoriesQueryTest
{
    [Fact]
    public async void GetSubCategoriesQuery_Return_NotFound()
    {
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();

        var mockCategoryRepository = new Mock<ICategoryRepository>();

        GetSubCategoriesQueryHandler handler = new(
            mockSubCategoryRepository.Object,
            mockCategoryRepository.Object);

        GetSubCategoriesQuery request = new(It.IsAny<Guid>());

        var getSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(getSubCategoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Category", request.CategoryId), getSubCategoryResult.FirstError);
    }
    
    [Fact]
    public async void GetSubCategoriesQuery_Return_SubCategory_List()
    {
        List<SubCategory> subCategoryList = [
            new SubCategory
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                Name = "Test",
                Description = "Test",
                CreatedAt = DateTimeOffset.Now
            }];

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository.Setup(x => x.GetSubCategoriesByCategory(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(subCategoryList);

        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Category());

        GetSubCategoriesQueryHandler handler = new(
            mockSubCategoryRepository.Object,
            mockCategoryRepository.Object);

        GetSubCategoriesQuery request = new(It.IsAny<Guid>());

        var getSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(getSubCategoryResult.IsError);
        Assert.Equal(subCategoryList, getSubCategoryResult);
    }
}
