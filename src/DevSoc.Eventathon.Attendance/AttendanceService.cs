using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Attendance;

public class AttendanceService : IAttendanceService
{
    public void RegisterAttendance(AttendanceDefinition definition)
    {
        Console.WriteLine(definition.EventId);
    }
}

