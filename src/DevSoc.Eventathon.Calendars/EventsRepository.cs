using DevSoc.Eventathon.Calendars.Models;
using ICalDavClient = CalDAV.NET.Interfaces.IClient;

namespace DevSoc.Eventathon.Calendars;

public class EventsRepository : IEventsRepository
{
    private readonly ICalDavClient _calDavClient;

    public EventsRepository(ICalDavClient calDavClient)
    {
        _calDavClient = calDavClient;
    }
    
    public Task<string> CreateEvent(EventDefinition definition)
    {
        throw new NotImplementedException();
    }
}