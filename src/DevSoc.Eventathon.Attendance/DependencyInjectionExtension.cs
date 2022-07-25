namespace DevSoc.Eventathon.Attendance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
public static class DependencyInjectionExtension
{
    public static IServiceCollection AddAttendance(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSingleton<IAttendanceService, AttendanceService>();
    }
}