using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Calendars;

public interface IEventsService
{
    Task<Event> GetEvent(string id);
    Task<IList<Event>> GetEvents();
    Task CreateEvent(global::Google.Apis.Calendar.v3.Data.Event definition);
}