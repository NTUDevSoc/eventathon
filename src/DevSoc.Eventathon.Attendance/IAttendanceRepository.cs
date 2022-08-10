using DevSoc.Eventathon.Attendance.Models;

namespace DevSoc.Eventathon.Attendance;

public interface IAttendanceRepository
{
    Task RegisterAttendance(AttendanceData definition);
    Task<List<string>> GetAttendingEvents(string userId);
    
}