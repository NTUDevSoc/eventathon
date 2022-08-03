using DevSoc.Eventathon.Attendance.Models;

namespace DevSoc.Eventathon.Attendance;
using DevSoc.Eventathon.Calendars.Models;

public interface IAttendanceRepository
{
    Task RegisterAttendance(AttendanceData definition);
    Task<List<string>> GetAttendingEvents(string userId);
    
}