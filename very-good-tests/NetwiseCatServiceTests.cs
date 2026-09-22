using Moq;
using netwise_recruitment_task.Clients.Interfaces;
using netwise_recruitment_task.DTOs;
using netwise_recruitment_task.Exceptions;
using netwise_recruitment_task.Repositories.Interfaces;
using netwise_recruitment_task.Services.Implementations;

namespace VeryGoodTests;

public class NetwiseCatServiceTests
{
    private readonly Mock<ICatClient> _clientMock = new();
    private readonly Mock<ICatRepository> _repositoryMock = new();

    [Fact]
    public async Task FetchAndSaveAsync_HappyPath_CallsRepositoryAppendAsync()
    {
        var fact = new GetCatFactDto { Fact = "Cats are cats, that is one the facts of all time." };
        _clientMock.Setup(c => c.GetCatFactAsync()).ReturnsAsync(fact);
        _repositoryMock.Setup(r => r.AppendAsync(fact.Fact)).Returns(Task.CompletedTask);
        var service = new NetwiseCatService(_clientMock.Object, _repositoryMock.Object);

        await service.FetchAndSaveAsync();

        _repositoryMock.Verify(r => r.AppendAsync(fact.Fact), Times.Once);
    }

    [Fact]
    public async Task FetchAndSaveAsync_FactNull_ThrowsNotFoundException()
    {
        _clientMock.Setup(c => c.GetCatFactAsync()).ReturnsAsync((GetCatFactDto?)null);
        var service = new NetwiseCatService(_clientMock.Object, _repositoryMock.Object);
        
        await Assert.ThrowsAsync<NotFoundException>(service.FetchAndSaveAsync);
    }
}