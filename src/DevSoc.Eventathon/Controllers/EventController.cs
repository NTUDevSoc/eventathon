using Microsoft.AspNetCore.Mvc;
namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class EventController : ControllerBase
{
    [HttpGet("api/test")]
    public Task<OkResult> GetEvent()
    {
        return Task.FromResult(new OkResult());
    }
}

