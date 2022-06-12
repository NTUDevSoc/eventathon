using DevSoc.Eventathon.Models;
namespace DevSoc.Eventathon.Calendars.Models;

public class EventRestResponse : EventResponse
{
    public EventResponse singleEvent { get; set; }
    
}