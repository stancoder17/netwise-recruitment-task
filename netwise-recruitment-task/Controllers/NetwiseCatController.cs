using Microsoft.AspNetCore.Mvc;
using netwise_recruitment_task.Exceptions;
using netwise_recruitment_task.Services.Interfaces;

namespace netwise_recruitment_task.Controllers;

[ApiController]
public class NetwiseCatController(ICatService service) : ControllerBase
{
    private readonly string _secretMessage = " /\\     /\\\n{  `---'  }\n{  O   O  }\n~~>  V  <~~\n \\  \\|/  /\n  `-----'____\n  /     \\    \\_\n {       }\\  )_\\_   _\n |  \\_/  |/ /  \\_\\_/ )\n  \\__/  /(_/     \\__/\n    (__/";
    
    [HttpGet("/cat_fact")]
    public async Task<IActionResult> GetCatFact()
    {
        try
        {
            await service.FetchAndSaveAsync();
            return Ok("Success!!!\n\n\n" + _secretMessage);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}