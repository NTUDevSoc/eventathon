namespace DevSoc.Eventathon.Attendance;
using DevSoc.Eventathon.Calendars.Models;

public interface IAttendanceService
{
    void RegisterAttendance(AttendanceDefinition definition);
}