using DevSoc.Eventathon.Calendars.Google;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSoc.Eventathon.Calendars;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddEvents(this IServiceCollection services, IConfiguration configuration)
    {
        return configuration.GetValue<bool>("Google:IsEnabled") ? 
            services.AddGoogleCalendar(configuration) :
            services.AddInMemoryEventsCalendar();
    }
    
    private static IServiceCollection AddGoogleCalendar(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<GoogleCalendarAuthenticationOptions>(configuration.GetSection(GoogleCalendarAuthenticationOptions.AppSettingsSection))
            .Configure<GoogleCalendarOptions>(configuration.GetSection(GoogleCalendarOptions.AppSettingsSection))
            .AddTransient<IGoogleCalendarServiceFactory, GoogleCalendarServiceFactory>()
            .AddTransient<IEventsService, GoogleCalendarEventsService>();
    }

    private static IServiceCollection AddInMemoryEventsCalendar(this IServiceCollection services)
    {
        return services.AddSingleton<IEventsService, InMemoryEventsService>();
    }
}