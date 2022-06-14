namespace DevSoc.Eventathon.Calendars.Google;

public class GoogleCalendarAuthenticationOptions
{
    public static string AppSettingsSection => "Google:Authentication";
    
    public string ApplicationName { get; set; }

    public string ServiceAccountEmail { get; set; }
    
    public string CertificatePath { get; set; }
    
    public string CertificatePassword { get; set; }
    
    public IList<string> Scopes { get; set; }
}