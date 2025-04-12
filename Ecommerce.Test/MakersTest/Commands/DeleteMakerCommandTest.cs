using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Makers.Commands.DeleteMaker;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.MakersTest.Commands;

public class DeleteMakerCommandTest
{
    [Fact]
    public async void DeleteMakerCommand_Return_Maker_NotFound()
    {
        var mockMakerRepository = new Mock<IMakerRepostory>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteMakerCommandHandler handler = new(mockMakerRepository.Object,
                                                mockUnitOfWork.Object);

        DeleteMakerCommand request = new(It.IsAny<Guid>());

        var createMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createMakerResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Maker", request.MakerId), createMakerResult.FirstError);
    }

    [Fact]
    public async void DeleteMakerCommand_Return_Deleted()
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

        DeleteMakerCommandHandler handler = new(mockMakerRepository.Object,
                                                mockUnitOfWork.Object);

        DeleteMakerCommand request = new(It.IsAny<Guid>());

        var deleteMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteMakerResult.IsError);
        Assert.Equal(new Deleted(), deleteMakerResult);
    }
}
