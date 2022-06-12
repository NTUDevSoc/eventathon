namespace DevSoc.Eventathon.Calendars.Models;

public class CalendarOptions
{
    public string? CalendarUrl { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public Uri CalendarUri => !string.IsNullOrEmpty(CalendarUrl) ?
        new Uri(CalendarUrl) :
        throw new InvalidOperationException($"Couldn't cast {nameof(CalendarUrl)} to Uri, as it was null or empty");
}