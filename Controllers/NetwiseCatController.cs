using Microsoft.AspNetCore.Mvc;
using netwise_task.Exceptions;
using netwise_task.Services.Interfaces;

namespace netwise_task.Controllers;

public class NetwiseCatController(ICatService service) : ControllerBase
{
    [HttpGet("/cat_fact")]
    public async Task<IActionResult> GetCatFact()
    {
        try
        {
            await service.FetchAndSaveAsync();
            return Ok("Success!!! :-)");
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Hello world: {e.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}