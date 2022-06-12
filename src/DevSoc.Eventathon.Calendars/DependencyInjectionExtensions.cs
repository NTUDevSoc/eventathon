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
        
        return services.AddTransient<IClient, Client>(provider =>
        {
            var calendarUrl = calendarConfigurationSection["Url"];
            var username = calendarConfigurationSection["Username"];
            var password = calendarConfigurationSection["Password"];
            
            return new Client(new Uri(calendarUrl), username, password);
        });
    }

    public static IServiceCollection AddEvents(this IServiceCollection services)
    {
        return services.AddTransient<IEventsRepository, EventsRepository>();
    }
}