using DevSoc.Eventathon.Calendars;
using DevSoc.Eventathon.Calendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventsService _eventsService;

    public EventsController(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    [HttpGet("api/events/{id}")]
    public async Task<IActionResult> GetEvent([FromRoute] string id)
    {
        Event result = await _eventsService.GetEvent(id);
        return Ok(result);
    }

    [HttpGet("api/events")]
    public async Task<IActionResult> GetEvents()
    {
        var events = await _eventsService.GetEvents();
        return Ok(events);
    }

    [HttpPost("api/events")]
    public async Task<IActionResult> CreateEvent([FromBody] EventDefinition definition)
    {
        // todo: change to use ClaimsPrincipal user
        Console.WriteLine(definition.Name + definition.Start + definition.End);
        // Todo: Store name, description, start, end on CalDev 
        return Ok(definition);
    }
}