using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class CalController
{
    [HttpGet("api/calendar")]

    public Task<OkResult> GetCal()
    {
        /* more JSON, probably! */
        return Task.FromResult(new OkResult());
    }
}