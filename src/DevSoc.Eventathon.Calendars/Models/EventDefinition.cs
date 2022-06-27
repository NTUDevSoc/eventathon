using Google.Apis.Calendar.v3.Data;

namespace DevSoc.Eventathon.Calendars.Models;

public class EventDefinition
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public EventDateTime? Start { get; set; }
    public EventDateTime? End  { get; set; }
}