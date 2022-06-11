using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class CalendarController : ControllerBase
{
    [HttpGet("api/calendar")]

    public Task<OkResult> GetCalendar()
    {
        /* more JSON, probably! */
        return Task.FromResult(new OkResult());
    }
}