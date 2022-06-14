using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Options;

namespace DevSoc.Eventathon.Calendars.Google;

public class GoogleCalendarServiceFactory : IGoogleCalendarServiceFactory
{
    private readonly IOptions<GoogleCalendarAuthenticationOptions> _googleCalendarApiOptions;

    public GoogleCalendarServiceFactory(IOptions<GoogleCalendarAuthenticationOptions> googleCalendarApiOptions)
    {
        _googleCalendarApiOptions = googleCalendarApiOptions;
    }

    public CalendarService Create()
    {
        var apiOptions = _googleCalendarApiOptions.Value;

        var certificate = new X509Certificate2(
            apiOptions.CertificatePath,
            apiOptions.CertificatePassword,
            X509KeyStorageFlags.Exportable);

        var credentialsInitializer = new ServiceAccountCredential.Initializer(apiOptions.ServiceAccountEmail)
        {
            Scopes = apiOptions.Scopes
        }.FromCertificate(certificate);

        return new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = new ServiceAccountCredential(credentialsInitializer),
            ApplicationName = apiOptions.ApplicationName
        });
    }
}