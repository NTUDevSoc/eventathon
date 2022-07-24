using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Options;

namespace DevSoc.Eventathon.Calendars.Google;

public class GoogleCalendarServiceFactory : IGoogleCalendarServiceFactory
{
    private readonly IOptions<GoogleCalendarAuthenticationOptions> _googleCalendarApiOptions;
    
    private readonly IList<string> _scopes = new List<string>
    {
        CalendarService.Scope.Calendar,
        CalendarService.Scope.CalendarEvents
    };

    public GoogleCalendarServiceFactory(IOptions<GoogleCalendarAuthenticationOptions> googleCalendarApiOptions)
    {
        _googleCalendarApiOptions = googleCalendarApiOptions;
    }

    public CalendarService Create()
    {
        var apiOptions = _googleCalendarApiOptions.Value;
        ArgumentNullException.ThrowIfNull(apiOptions);
        
        apiOptions.ThrowIfInvalid();

        var json = JsonSerializer.Serialize(apiOptions.Credentials);
        var credentials = GoogleCredential.FromJson(json)
            .CreateScoped(_scopes)
            .CreateWithUser(apiOptions.ImpersonateUser);

        return new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credentials,
            ApplicationName = apiOptions.ApplicationName
        });
    }
}