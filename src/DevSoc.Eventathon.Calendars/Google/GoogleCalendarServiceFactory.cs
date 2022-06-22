using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
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

        if (!DoCredentialsExist(apiOptions.CredentialsPath))
        {
            throw new InvalidOperationException($"Invalid path supplied for Google calendar credentials: {apiOptions.CredentialsPath}");
        }

        using var stream = new FileStream(apiOptions.CredentialsPath, FileMode.Open, FileAccess.Read);
        var credentials = GoogleCredential.FromStream(stream)
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