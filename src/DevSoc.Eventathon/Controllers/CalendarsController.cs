using DevSoc.Eventathon.Calendars;
using Ical.Net;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class CalendarsController : ControllerBase
{
    private readonly IEventsRepository _eventsRepository;

    public CalendarsController(IEventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }
    
    [HttpGet("api/calendars")]
    public async Task<ActionResult<List<Calendar>>> GetCalendars()
    {
        var calendars = await _eventsRepository.GetCalendars();
        return new OkObjectResult(calendars);
    }
}