using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.SubCategories.Queries.GetSubCategory;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.SubCategoriesTest.Queries;

public class GetSubCategoryQueryTest
{
    [Fact]
    public async void GetSubCategoriesQuery_Return_NotFound()
    {
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();

        GetSubCategoryQueryHandler handler = new(mockSubCategoryRepository.Object);

        GetSubCategoryQuery request = new(It.IsAny<Guid>());

        var getSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(getSubCategoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("SubCategory", request.SubCategoryId), getSubCategoryResult.FirstError);
    }

    [Fact]
    public async void GetSubCategoriesQuery_Return_SubCategory()
    {
        var subCategory = new SubCategory 
        { 
            Id = Guid.NewGuid(),
            CategoryId = Guid.NewGuid(),
            Name = "Test",
            Description = "Test",
            CreatedAt = DateTimeOffset.Now
        };

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository.Setup(x => x.GetSubCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(subCategory);

        GetSubCategoryQueryHandler handler = new(mockSubCategoryRepository.Object);

        GetSubCategoryQuery request = new(It.IsAny<Guid>());

        var getSubCategoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(getSubCategoryResult.IsError);
        Assert.Equal(subCategory, getSubCategoryResult);
    }
}
