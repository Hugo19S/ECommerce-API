using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Makers.Queries.GetMakers;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.MakersTest.Queries;

public class GetMakersQueryTest
{
    [Fact]
    public async void GetMakersQuery_Return_Maker()
    {
        List<Maker> makerList =
        [
            new Maker
            {
                Id = Guid.NewGuid(),
                Name = "name",
                CreatedAt = DateTimeOffset.UtcNow,
            }
        ];

        var mockMakerRepository = new Mock<IMakerRepostory>();
        mockMakerRepository.Setup(x => x.GetAllMaker(It.IsAny<CancellationToken>()))
            .ReturnsAsync(makerList);

        GetMakersQueryHandler handler = new(mockMakerRepository.Object);

        GetMakersQuery request = new();

        var deleteMakerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteMakerResult.IsError);
        Assert.Equal(makerList, deleteMakerResult);
    }
}
