namespace DevSoc.Eventathon.Calendars.Google;

public class GoogleCalendarOptions
{
    public static string AppSettingsSection => "Google:Calendar";
    
    public string? EventsCalendarId { get; set; }
}