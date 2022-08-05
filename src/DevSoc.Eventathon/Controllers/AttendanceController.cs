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
    public Task<IActionResult> ConfirmAttendance([FromBody] AttendanceDefinition definition)
    {
        _attendanceService.RegisterAttendance(definition);
        return Task.FromResult<IActionResult>(new OkResult());
    }
    
    [HttpGet("api/attendingEvents/{userId}")]
    public async Task<IActionResult> GetAttendingEvents([FromRoute] string userId)
    {
        var events = await _attendanceService.GetAttendingEvents(userId);
        return Ok(events);
    }
}