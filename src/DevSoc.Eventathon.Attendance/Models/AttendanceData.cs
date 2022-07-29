using System.ComponentModel.DataAnnotations.Schema;
namespace DevSoc.Eventathon.Attendance.Models;

[Table("public.attendance")]
public class AttendanceData
{
    [Column("user_id")]
    public string UserId { get; set; } = "";
    
    [Column("event_id")]
    public string EventId { get; set; } = "";
}