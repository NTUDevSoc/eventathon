using DevSoc.Eventathon.Calendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class AttendanceController : ControllerBase
{

    [HttpPost("api/attendance")]
    public Task<IActionResult> ConfirmAttendance([FromBody] AttendanceDefinition definition)
    {
        // todo: implement attendance
        Console.WriteLine(definition.UserId);
        return Task.FromResult<IActionResult>(new OkResult());
    }
}