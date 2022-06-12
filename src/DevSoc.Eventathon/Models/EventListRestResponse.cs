using DevSoc.Eventathon.Models;
namespace DevSoc.Eventathon.Calendars.Models;

public class EventListRestResponse : EventResponse
{
    public EventResponse[] eventList { get; set; }
    
}