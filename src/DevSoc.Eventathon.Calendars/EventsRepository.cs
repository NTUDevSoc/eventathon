using DevSoc.Eventathon.Calendars.Models;
using Ical.Net;
using ICalDavClient = CalDAV.NET.Interfaces.IClient;
using DevSoc.Eventathon.Models;
namespace DevSoc.Eventathon.Calendars;

public class EventsRepository : IEventsRepository
{
    private readonly ICalDavClient _calDavClient;

    public EventsRepository(ICalDavClient calDavClient)
    {
        _calDavClient = calDavClient;
    }

    public async Task<EventResponse> GetEvent(string id)
    {
        return new MockData().GetSingleEvent();
    }

    public async Task<EventResponse[]> GetEvents()
    {
        return new MockData().GetMultipleEvents();
    }
    
    public async Task<string> CreateEvent(EventDefinition definition)
    {
        var calendarToUse = await _calDavClient.GetDefaultCalendarAsync();
        var eventCreated = calendarToUse.CreateEvent(definition.Name, definition.Start, definition.End);

        return eventCreated.Uid;
    }

    public async Task<bool> DeleteEvent(string uid)
    {
        var calendarToUse = await _calDavClient.GetDefaultCalendarAsync();
        var eventToDel = calendarToUse.Events.FirstOrDefault(@event => @event.Uid == uid);
        if (eventToDel != null)
        {
            calendarToUse.DeleteEvent(eventToDel);
            return true;
        }

        return false;
    }

    public async Task<string> EditEvent(string uid, EventDefinition newDefinition)
    {
        var calendarToUse = await _calDavClient.GetDefaultCalendarAsync();
        var eventToEdit = calendarToUse.Events.FirstOrDefault(@event => @event.Uid == uid);
        if (eventToEdit != null)
        {
            calendarToUse.DeleteEvent(eventToEdit);
            eventToEdit = calendarToUse.CreateEvent(newDefinition.Name, newDefinition.Start, newDefinition.End);
            return eventToEdit.Uid;
        }

        return null;
    }
}