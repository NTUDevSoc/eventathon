using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Calendars;

public interface IEventsService
{
    Task<IList<Event>> GetEvents();
    Task<bool> DeleteEvent();
    
}