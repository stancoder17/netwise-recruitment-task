using Microsoft.Extensions.Configuration;
using Moq;
using netwise_recruitment_task.Repositories.Implementations;

namespace VeryGoodTests;

public class NetwiseCatFileRepositoryTests
{
    private readonly Mock<IConfiguration> _configurationMock = new();
    
    [Fact]
    public async Task AppendAsync_HappyPath_AppendsContentToFile()
    {
        _configurationMock.Setup(c => c["CatApiSettings:FilePath"]).Returns("test.txt");
        var repository = new NetwiseCatFileRepository(_configurationMock.Object);

        await repository.AppendAsync("Test content");

        Assert.True(File.Exists("test.txt"));
        var content = await File.ReadAllTextAsync("test.txt");
        Assert.Contains("Test content", content);
    }

    [Fact]
    public void CreateRepositoryObject_ConfigFilePathMissing_ThrowsInvalidOperationException()
    {
        _configurationMock.Setup(c => c["CatApiSettings:FilePath"]).Returns((string?)null);

        Assert.Throws<InvalidOperationException>(() => new NetwiseCatFileRepository(_configurationMock.Object));
    }
}