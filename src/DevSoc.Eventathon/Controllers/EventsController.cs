using DevSoc.Eventathon.Models;
﻿using DevSoc.Eventathon.Calendars;
using DevSoc.Eventathon.Calendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventsRepository _eventsRepository;

    public EventsController(IEventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    [HttpGet("api/events/{id}")]
    public async Task<IActionResult> GetEvent([FromRoute] string id)
    {
        // todo
        return Ok(new MockData().getSingleEvent());

    }

    [HttpGet("api/events")]
    public async Task<IActionResult> GetEvents()
    {
        // todo
        return Ok(new MockData().getMultipleEvents());
    }

    [HttpPost("api/events")]
    public async Task<IActionResult> CreateEvent([FromBody] EventDefinition definition)
    {
        // todo: change to use ClaimsPrincipal user
        Console.WriteLine(definition.Name + definition.Start + definition.End);
        // Todo: Store name, description, start, end on CalDev 
        return Ok(definition);
    }

    [HttpDelete("api/events/{uid}")]
    public async Task<IActionResult> DeleteEvent([FromRoute] string uid)
    {
        bool result = await _eventsRepository.DeleteEvent(uid);

        if (result != true)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPost("api/events/{uid}")]
    public async Task<IActionResult> EditEvent([FromRoute] string uid, [FromBody] EventDefinition definition)
    {
        string result = await _eventsRepository.EditEvent(uid, definition);
        if (result != "") //I'm basically trying to check for 'nothing' here - need to check CalDAV.NET.
        {
            return NotFound();
        }

        return Ok();
    }
    }
}