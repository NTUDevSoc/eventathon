using Microsoft.AspNetCore.Mvc;
namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class EventController : ControllerBase
{
    [HttpPost("api/test")]
    public Task<OkResult> CreateEvent()
    {
        return Task.FromResult(new OkResult());
    }
}

