using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Calendars;

public interface IEventsRepository
{
    Task<string> CreateEvent(EventDefinition definition);
}