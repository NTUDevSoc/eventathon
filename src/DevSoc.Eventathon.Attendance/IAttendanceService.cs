using DevSoc.Eventathon.Calendars.Models;
namespace DevSoc.Eventathon.Attendance;

public interface IAttendanceService
{
    void RegisterAttendance(AttendanceDefinition definition);
    Task<List<string>> GetAttendingEvents(string userId);
}

