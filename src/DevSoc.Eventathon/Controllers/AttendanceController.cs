using DevSoc.Eventathon.Calendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class AttendanceController : ControllerBase
{

    [HttpPost("api/attendance")]
    public async Task<IActionResult> ConfirmAttendance([FromBody] AttendanceDefinition definition)
    {
        // todo: change to use ClaimsPrincipal user
        Console.WriteLine(definition.UserID + definition.EventID + definition.Name);
        // Todo: Store attendance along with user data 
        return new OkResult();
    }
}