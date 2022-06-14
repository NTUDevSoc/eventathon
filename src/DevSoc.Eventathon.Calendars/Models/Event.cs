namespace DevSoc.Eventathon.Calendars.Models;

public class Event
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }

    internal static Event FromGoogleEvent(global::Google.Apis.Calendar.v3.Data.Event @event)
    {
        return new Event
        {
            Id = @event.Id,
            Title = @event.Summary,
            Description = @event.Description,
            Start = @event.Start.DateTime,
            End = @event.End.DateTime,
        };
    }
}