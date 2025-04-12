using Ecommerce.Application.Categories.Queries.GetCategories;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.CategoriesTest.Queries;

public class GetCategoriesQueryTest
{
    [Fact]
    public async void GetCategoriesQuery_Return_Category_List()
    {
        List<Category> categoryList = [
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Description = "Test",
                CreatedAt = DateTimeOffset.Now,
            }];

        var mockUserRepository = new Mock<ICategoryRepository>();
        mockUserRepository.Setup(x => x.GetAllCategories(It.IsAny<CancellationToken>()))
            .ReturnsAsync(categoryList);

        GetCategoriesQueryHandler handler = new(mockUserRepository.Object);

        GetCategoriesQuery request = new();

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(patchCategotyResult.IsError);
        Assert.Equal(categoryList, patchCategotyResult);
    }
}
