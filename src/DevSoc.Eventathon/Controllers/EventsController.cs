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
        var @event = await _eventsService.GetEvent(id);
        return Ok(@event);
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
        var eventId = await _eventsService.CreateEvent(definition);
        return Ok(eventId);
    }
}