using DevSoc.Eventathon.Calendars.Google;
using DevSoc.Eventathon.Calendars.Models;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Microsoft.Extensions.Options;
using Event = DevSoc.Eventathon.Calendars.Models.Event;

namespace DevSoc.Eventathon.Calendars;

public class EventsService : IEventsService
{
    private readonly IGoogleCalendarServiceFactory _googleCalendarServiceFactory;
    private readonly IOptions<GoogleCalendarOptions> _googleCalendarOptions;

    public EventsService(IGoogleCalendarServiceFactory googleCalendarServiceFactory, IOptions<GoogleCalendarOptions> googleCalendarOptions)
    {
        _googleCalendarServiceFactory = googleCalendarServiceFactory;
        _googleCalendarOptions = googleCalendarOptions;
    }

    public async Task<Event> GetEvent(string id)
    {
        var calendarService = _googleCalendarServiceFactory.Create();
        var request = calendarService.Events.Get(_googleCalendarOptions.Value.EventsCalendarId, id);
        var @event = await request.ExecuteAsync();
        return Event.FromGoogleEvent(@event);
    }

    public async Task<IList<Event>> GetEvents()
    {
        var calendarService = _googleCalendarServiceFactory.Create();
        var request = calendarService.Events.List(_googleCalendarOptions.Value.EventsCalendarId);

        var events = await request.ExecuteAsync();
        return events.Items.Select(Event.FromGoogleEvent).ToList();
    }
    
    public async Task CreateEvent(EventDefinition definition)
    {
        var googleEvent = new global::Google.Apis.Calendar.v3.Data.Event
        {
            Start = new EventDateTime { DateTime = definition.Start},
            End = new EventDateTime { DateTime = definition.End},
            Summary = definition.Name,
            Description = definition.Description
        };
        var calendarService = _googleCalendarServiceFactory.Create();
        await calendarService.Events.Insert(googleEvent, _googleCalendarOptions.Value.EventsCalendarId).ExecuteAsync();
    }
}