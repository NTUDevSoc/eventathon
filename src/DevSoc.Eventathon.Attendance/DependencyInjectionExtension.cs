using DevSoc.Eventathon.Data;
namespace DevSoc.Eventathon.Attendance;
using Microsoft.Extensions.DependencyInjection;
public static class DependencyInjectionExtension
{
    public static IServiceCollection AddAttendance(this IServiceCollection services)
    {
        return services
            .AddTransient<IAttendanceRepository, AttendanceRepository>()
            .AddSingleton<IAttendanceService, AttendanceService>();
    }
}