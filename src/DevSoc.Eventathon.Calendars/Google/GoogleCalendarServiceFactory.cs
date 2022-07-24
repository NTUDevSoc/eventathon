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

    public async Task<CalendarService> Create()
    {
        var apiOptions = _googleCalendarApiOptions.Value;
        ArgumentNullException.ThrowIfNull(apiOptions);
        
        apiOptions.ThrowIfInvalid();

        using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, apiOptions.GoogleCredentialSettings);
        var credentials = (await GoogleCredential.FromStreamAsync(stream, CancellationToken.None))
            .CreateScoped(_scopes)
            .CreateWithUser(apiOptions.ImpersonateUser);

        return new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credentials,
            ApplicationName = apiOptions.ApplicationName
        });
    }

    private static bool DoCredentialsExist([NotNullWhen(true)] string? credentialsPath) => 
        !string.IsNullOrEmpty(credentialsPath) && File.Exists(credentialsPath);
}