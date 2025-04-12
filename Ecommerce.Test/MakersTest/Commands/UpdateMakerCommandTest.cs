using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Makers.Commands.UpdateMaker;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.MakersTest.Commands;

public class UpdateMakerCommandTest
{
    [Fact]
    public async void UpdateMakerCommand_Return_Maker_NotFound()
    {
        var mockMakerRepository = new Mock<IMakerRepostory>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateMakerCommandHandler handler = new(mockMakerRepository.Object, mockUnitOfWork.Object);

        UpdateMakerCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updateMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateMakerResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Maker", request.MakerId), updateMakerResult.FirstError);
    }

    [Fact]
    public async void CreateMakerCommand_Return_Maker_Conflict()
    {
        var maker = new Maker
        {
            Id = Guid.NewGuid(),
            Name = "name",
            CreatedAt = DateTimeOffset.UtcNow,
        };

        var mockMakerRepository = new Mock<IMakerRepostory>();
        mockMakerRepository.Setup(x => x.GetMakerById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(maker);
        mockMakerRepository.Setup(x => x.GetMakerByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(maker);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateMakerCommandHandler handler = new(mockMakerRepository.Object, mockUnitOfWork.Object);

        UpdateMakerCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updateMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateMakerResult.IsError);
        Assert.Equal(DomainErrors.Conflict("Maker"), updateMakerResult.FirstError);
    }

    [Fact]
    public async void UpdateMakerCommand_Return_Deleted()
    {
        var maker = new Maker
        {
            Id = Guid.NewGuid(),
            Name = "name",
            CreatedAt = DateTimeOffset.UtcNow,
        };

        var mockMakerRepository = new Mock<IMakerRepostory>();
        mockMakerRepository.Setup(x => x.GetMakerById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(maker);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateMakerCommandHandler handler = new(mockMakerRepository.Object,
                                                mockUnitOfWork.Object);

        UpdateMakerCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updateMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(updateMakerResult.IsError);
        Assert.Equal(new Updated(), updateMakerResult);
    }
}
