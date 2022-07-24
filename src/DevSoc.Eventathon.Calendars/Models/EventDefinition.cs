using Google.Apis.Calendar.v3.Data;

namespace DevSoc.Eventathon.Calendars.Models;

public class EventDefinition
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }

    public global::Google.Apis.Calendar.v3.Data.Event ToGoogleEvent()
    {
        return new global::Google.Apis.Calendar.v3.Data.Event
        {
            Start = new EventDateTime { DateTime = Start },
            End = new EventDateTime { DateTime = End },
            Summary = Name,
            Description = Description
        };
    }
}