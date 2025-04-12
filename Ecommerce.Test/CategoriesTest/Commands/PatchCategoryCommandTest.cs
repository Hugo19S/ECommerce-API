using Ecommerce.Application.Categories.Commands.PatchCategory;
using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Microsoft.AspNetCore.JsonPatch;
using Moq;

namespace Ecommerce.Tests.CategoriesTest.Commands;

public class PatchCategoryCommandTest
{
    [Fact]
    public async void PatchCategoryCommand_Return_Operation_Unauthorized()
    {
        JsonPatchDocument<Category> jsonPatch = new();
        jsonPatch.Move(c => c.CreatedAt, c => c.UpdatedAt);
        jsonPatch.Copy(c => c.CreatedAt, c => c.UpdatedAt);

        var mockUserRepository = new Mock<ICategoryRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        PatchCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        PatchCategoryCommand request = new(It.IsAny<Guid>(), jsonPatch);

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(patchCategotyResult.IsError);
        Assert.Equal(DomainErrors.OperationUnauthorized(), patchCategotyResult.FirstError);
    }
    
    [Fact]
    public async void PatchCategoryCommand_Return_Operation_Path_Unauthorized()
    {
        JsonPatchDocument<Category> jsonPatch = new();
        jsonPatch.Replace(c => c.CreatedAt, new DateTimeOffset(2024, 02, 09, 12, 30, 00, TimeSpan.Zero));

        var mockUserRepository = new Mock<ICategoryRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        PatchCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        PatchCategoryCommand request = new(It.IsAny<Guid>(), jsonPatch);

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(patchCategotyResult.IsError);
        Assert.Equal(DomainErrors.OperationPathUnauthorized(), patchCategotyResult.FirstError);
    }
    
    [Fact]
    public async void PatchCategoryCommand_Return_JSonPatchNotFound()
    {
        JsonPatchDocument<Category> jsonPatch = new();

        var mockUserRepository = new Mock<ICategoryRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        PatchCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        PatchCategoryCommand request = new(It.IsAny<Guid>(), jsonPatch);

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(patchCategotyResult.IsError);
        Assert.Equal(DomainErrors.JSonPatchNotFound(), patchCategotyResult.FirstError);
    }

    [Fact]
    public async void PatchCategoryCommand_Return_Category_NotFound()
    {
        JsonPatchDocument<Category> jsonPatch = new();
        jsonPatch.Replace(c => c.Name, "Updated");

        var mockUserRepository = new Mock<ICategoryRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        PatchCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        PatchCategoryCommand request = new(It.IsAny<Guid>(), jsonPatch);

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(patchCategotyResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Category", request.CategoryId), patchCategotyResult.FirstError);
    }

    [Fact]
    public async void PatchCategoryCommand_Return_Category_Conflict()
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Test",
            CreatedAt = DateTimeOffset.Now,
        };

        JsonPatchDocument<Category> jsonPatch = new();
        jsonPatch.Replace(c => c.Name, "Test");

        var mockUserRepository = new Mock<ICategoryRepository>();
        mockUserRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);
        mockUserRepository.Setup(x => x.GetCategoryByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        PatchCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        PatchCategoryCommand request = new(It.IsAny<Guid>(), jsonPatch);

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(patchCategotyResult.IsError);
        Assert.Equal(DomainErrors.CategoryTypeConflict(), patchCategotyResult.FirstError);
    }
    
    [Fact]
    public async void PatchCategoryCommand_Return_Category_Updated()
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Test",
            CreatedAt = DateTimeOffset.Now,
        };

        JsonPatchDocument<Category> jsonPatch = new();
        jsonPatch.Replace(c => c.Name, "Test");

        var mockUserRepository = new Mock<ICategoryRepository>();
        mockUserRepository.Setup(x => x.GetCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        PatchCategoryCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        PatchCategoryCommand request = new(It.IsAny<Guid>(), jsonPatch);

        var patchCategotyResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(patchCategotyResult.IsError);
        Assert.Equal(new Updated(), patchCategotyResult);
    }
}
