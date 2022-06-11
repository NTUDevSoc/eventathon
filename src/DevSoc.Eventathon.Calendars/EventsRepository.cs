using CalDAV.NET.Interfaces;
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

    public async Task<List<ICalendar>> GetCalendars()
    {
        var calendars = await _calDavClient.GetCalendarsAsync();
        return calendars.ToList();
    }

    public Task<string> CreateEvent(EventDefinition definition)
    {
        throw new NotImplementedException();
    }
}