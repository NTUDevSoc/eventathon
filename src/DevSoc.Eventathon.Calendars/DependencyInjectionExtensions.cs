using CalDAV.NET;
using CalDAV.NET.Interfaces;
using DevSoc.Eventathon.Calendars.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSoc.Eventathon.Calendars;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCalendars(this IServiceCollection services, IConfiguration configuration)
    {
        var calendarConfigurationSection = configuration.GetRequiredSection("Calendar");
        
        services.Configure<CalendarOptions>(options =>
        {
            options.CalendarUrl = calendarConfigurationSection["Url"];
            options.Username = calendarConfigurationSection["Username"];
            options.Password = calendarConfigurationSection["Password"];
        });

        return services.AddTransient<IClient, Client>(provider =>
        {
            var calendarOptions = provider.GetRequiredService<CalendarOptions>();
            return new Client(calendarOptions.CalendarUri, calendarOptions.Username, calendarOptions.Password);
        });
    }

    public static IServiceCollection AddEvents(this IServiceCollection services)
    {
        return services.AddTransient<IEventsRepository, EventsRepository>();
    }
}