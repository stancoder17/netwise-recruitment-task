using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using netwise_recruitment_task.Controllers;
using netwise_recruitment_task.Exceptions;
using netwise_recruitment_task.Services.Interfaces;

namespace VeryGoodTests;

public class NetwiseCatControllerTests
{
    private readonly Mock<ICatService> _serviceMock = new();
    
    [Fact]
    public async Task GetCatFact_HappyPath_ReturnsOk()
    {
        _serviceMock.Setup(s => s.FetchAndSaveAsync()).Returns(Task.CompletedTask);
        var controller = new NetwiseCatController(_serviceMock.Object);
        
        var result = await controller.GetCatFact();
        
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetCatFact_NotFoundException_Returns404()
    {
        _serviceMock
            .Setup(s => s.FetchAndSaveAsync())
            .ThrowsAsync(new NotFoundException("So uncivilized."));
        var controller = new NetwiseCatController(_serviceMock.Object);

        var result = await controller.GetCatFact();
        
        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFound.StatusCode);
    }

    [Fact]
    public async Task GetCatFact_Exception_Returns500()
    {
        _serviceMock
            .Setup(s => s.FetchAndSaveAsync())
            .ThrowsAsync(new Exception("How did this happen? We're smarter than this!"));
        var controller = new NetwiseCatController(_serviceMock.Object);

        var result = await controller.GetCatFact();
        
        var internalServerError = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, internalServerError.StatusCode);
    }
}