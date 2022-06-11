namespace DevSoc.Eventathon.Calendars.Models;

public class CalendarOptions
{
    public string CalendarUrl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public Uri CalendarUri => new Uri(CalendarUrl);
}