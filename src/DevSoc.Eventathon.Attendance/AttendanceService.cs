using DevSoc.Eventathon.Attendance.Models;
using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Attendance;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceService(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }


    public async Task RegisterAttendance(AttendanceDefinition definition)
    {
        var attendanceData = new AttendanceData
        {
            UserId = definition.UserId,
            EventId = definition.EventId
        };

        await _attendanceRepository.RegisterAttendance(attendanceData);
    }

    public async Task<List<string>> GetAttendingEvents(string userId)
    {
        return await _attendanceRepository.GetAttendingEvents(userId);
    }
}