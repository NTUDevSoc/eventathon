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
        Console.WriteLine(definition.Name + definition.Description + definition.Start + definition.End);
        await _eventsService.CreateEvent(definition);
        return Ok(definition);
    }
}