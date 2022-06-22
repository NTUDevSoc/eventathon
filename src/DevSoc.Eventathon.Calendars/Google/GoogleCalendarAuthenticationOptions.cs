namespace DevSoc.Eventathon.Calendars.Google;

public class GoogleCalendarAuthenticationOptions
{
    public static string AppSettingsSection => "Google:Authentication";
    
    public string ApplicationName { get; set; }

    public string ImpersonateUser { get; set; }

    public string CredentialsPath { get; set; }
}