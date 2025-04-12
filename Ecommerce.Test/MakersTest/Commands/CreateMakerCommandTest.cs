using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Makers.Commands.CreateMaker;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.MakersTest.Commands;

public class CreateMakerCommandTest
{
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
        mockMakerRepository.Setup(x => x.GetMakerByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(maker);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateMakerCommandHandler handler = new(mockMakerRepository.Object,
                                                mockUnitOfWork.Object);

        CreateMakerCommand request = new(It.IsAny<string>());

        var createMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createMakerResult.IsError);
        Assert.Equal(DomainErrors.Conflict("Maker"), createMakerResult.FirstError);
    }
    
    [Fact]
    public async void CreateMakerCommand_Return_Created()
    {
        var mockMakerRepository = new Mock<IMakerRepostory>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateMakerCommandHandler handler = new(mockMakerRepository.Object,
                                                mockUnitOfWork.Object);

        CreateMakerCommand request = new(It.IsAny<string>());

        var createMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createMakerResult.IsError);
        Assert.Equal(new Created(), createMakerResult);
    }
}
