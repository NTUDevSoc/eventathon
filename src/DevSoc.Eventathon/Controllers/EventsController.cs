using DevSoc.Eventathon.Calendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
    public EventsController()
    {
    }

    [HttpGet("api/events/{id}")]
    public async Task<IActionResult> GetEvents([FromRoute] string id)
    {
        // todo
        return new OkResult();
    }
    
    [HttpPost("api/events")]
    public async Task<IActionResult> CreateEvent([FromBody] EventDefinition definition)
    {
        // todo: change to use ClaimsPrincipal user
        return new OkResult();
    }
}