using DevSoc.Eventathon.Calendars.Models;
namespace DevSoc.Eventathon.Attendance;

public interface IAttendanceService
{
    Task RegisterAttendance(AttendanceDefinition definition);
    Task<List<string>> GetAttendingEvents(string userId);
}

