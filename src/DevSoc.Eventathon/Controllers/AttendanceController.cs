using DevSoc.Eventathon.Calendars.Models;
using DevSoc.Eventathon.Attendance;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;
    
    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }
    
    [HttpPost("api/attendance")]
    public async Task<IActionResult> ConfirmAttendance([FromBody] AttendanceDefinition definition)
    {
        await _attendanceService.RegisterAttendance(definition);
        return Ok();
    }
    
    [HttpGet("api/attendingEvents/{userId}")]
    public async Task<IActionResult> GetAttendingEvents([FromRoute] string userId)
    {
        var events = await _attendanceService.GetAttendingEvents(userId);
        return Ok(events);
    }
}