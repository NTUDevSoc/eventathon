using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Calendars;

public class InMemoryEventsService : IEventsService
{
    private readonly IList<Event> _events = new List<Event>();
    
    public Task<Event?> GetEvent(string id)
    {
        return Task.FromResult(_events.SingleOrDefault(@event => @event.Id == id));
    }

    public Task<IList<Event>> GetEvents()
    {
        return Task.FromResult(_events);
    }

    public Task<string> CreateEvent(EventDefinition definition)
    {
        var eventId = Guid.NewGuid().ToString();
        _events.Add(Event.FromDefinition(eventId, definition));

        return Task.FromResult(eventId);
    }
}