using DevSoc.Eventathon.Calendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
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
        Console.WriteLine(definition.Name + definition.Description + definition.Start + definition.End);
        // Todo: Store name, description, start, end on CalDev 
        return new OkResult();
    }
}