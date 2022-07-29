using Dapper;
using DevSoc.Eventathon.Attendance;
using DevSoc.Eventathon.Attendance.Models;
using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Data;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly IConnectionManager _connectionManager;

    public AttendanceRepository(IConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }
    
    public async void RegisterAttendance(AttendanceData attendanceData)
    {
        using var connection = await _connectionManager.Open();
        using var transaction = connection.BeginTransaction();

        const string insertQuery = @"
        INSERT INTO public.attendance
        (""user_id"", ""event_id"")
        VALUES(@UserId, @EventId);";

        await connection.ExecuteAsync(insertQuery, attendanceData);
        transaction.Commit();
    }

    public async Task<List<string>> GetAttendingEvents(string userId)
    {
        using var connection = await _connectionManager.Open();
        const string query = "SELECT attendance.event_id FROM public.attendance WHERE attendance.user_id = @userId";
        using (connection)
        {
            return connection.Query<string>(query, new { userId }).ToList();
        }
    }
}

