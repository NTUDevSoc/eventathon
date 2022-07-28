namespace DevSoc.Eventathon.Attendance;
using DevSoc.Eventathon.Calendars.Models;

public interface IAttendanceService
{
    void RegisterAttendance(AttendanceDefinition definition);
    Task<List<string>> GetAttendingEvents(string userId);
    
}