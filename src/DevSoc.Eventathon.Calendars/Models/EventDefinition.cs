namespace DevSoc.Eventathon.Calendars.Models;

public class EventDefinition
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End  { get; set; }
}