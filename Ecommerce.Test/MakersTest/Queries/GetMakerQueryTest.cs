using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Makers.Queries.GetMaker;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.MakersTest.Queries;

public class GetMakerQueryTest
{
    [Fact]
    public async void GetMakerQuery_Return_NotFound()
    {
        var mockMakerRepository = new Mock<IMakerRepostory>();

        GetMakerQueryHandler handler = new(mockMakerRepository.Object);

        GetMakerQuery request = new(It.IsAny<Guid>());

        var getMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(getMakerResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Maker", request.MakerId), getMakerResult.FirstError);
    }

    [Fact]
    public async void GetMakerQuery_Return_Maker()
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

        GetMakerQueryHandler handler = new(mockMakerRepository.Object);

        GetMakerQuery request = new(It.IsAny<Guid>());

        var deleteMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteMakerResult.IsError);
        Assert.Equal(maker, deleteMakerResult);
    }
}
