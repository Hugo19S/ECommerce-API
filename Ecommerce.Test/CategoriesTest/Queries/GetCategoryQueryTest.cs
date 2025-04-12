using Ecommerce.Application.Categories.Queries.GetCategory;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.CategoriesTest.Queries;

public class GetCategoryQueryTest
{
    [Fact]
    public async void GetCategoryQueryTest_Return_Category_NotFound()
    {
        var mockUserRepository = new Mock<ICategoryRepository>();

        GetCategoryQueryHandler handler = new(mockUserRepository.Object);

        GetCategoryQuery request = new(It.IsAny<Guid>());

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(patchCategotyResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Category", request.CategoryId), patchCategotyResult.FirstError);
    }
    
    [Fact]
    public async void GetCategoryQueryTest_Return_Category()
    {
        Category category = new()
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Test",
            CreatedAt = DateTimeOffset.Now,
        };

        var mockUserRepository = new Mock<ICategoryRepository>();
        mockUserRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        GetCategoryQueryHandler handler = new(mockUserRepository.Object);

        GetCategoryQuery request = new(It.IsAny<Guid>());

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(patchCategotyResult.IsError);
        Assert.Equal(category, patchCategotyResult);
    }
}
