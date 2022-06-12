using DevSoc.Eventathon.Calendars.Models;
using DevSoc.Eventathon.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
    [HttpGet("api/events/{id}")]
    public async Task<IActionResult> GetEvent([FromRoute] string id)
    {
        // todo
        EventRestResponse myEvent = new MockData().getSingleEvent();
        return Ok(myEvent);
    }

    [HttpGet("api/events")]
    public async Task<IActionResult> GetEvents()
    {
        // todo
        EventListRestResponse myEventList = new MockData().getMultipleEvents();
        return Ok(myEventList);
    }

    [HttpPost("api/events")]
    public async Task<IActionResult> CreateEvent([FromBody] EventDefinition definition)
    {
        // todo: change to use ClaimsPrincipal user
        Console.WriteLine(definition.Name + definition.Description + definition.Start + definition.End);
        // Todo: Store name, description, start, end on CalDev 
        return Ok(definition);
    }
}