using DevSoc.Eventathon.Calendars.Google;
using DevSoc.Eventathon.Calendars.Models;
using Google.Apis.Calendar.v3.Data;
using Microsoft.Extensions.Options;
using Event = DevSoc.Eventathon.Calendars.Models.Event;

namespace DevSoc.Eventathon.Calendars;

public class GoogleCalendarEventsService : IEventsService
{
    private readonly IGoogleCalendarServiceFactory _googleCalendarServiceFactory;
    private readonly IOptions<GoogleCalendarOptions> _googleCalendarOptions;

    public GoogleCalendarEventsService(IGoogleCalendarServiceFactory googleCalendarServiceFactory, IOptions<GoogleCalendarOptions> googleCalendarOptions)
    {
        _googleCalendarServiceFactory = googleCalendarServiceFactory;
        _googleCalendarOptions = googleCalendarOptions;
    }

    public async Task<Event?> GetEvent(string id)
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
    
    public async Task<string> CreateEvent(EventDefinition definition)
    {
        var calendarService = _googleCalendarServiceFactory.Create();
        var response = await calendarService.Events
            .Insert(definition.ToGoogleEvent(), _googleCalendarOptions.Value.EventsCalendarId)
            .ExecuteAsync();

        return response.Id;
    }
}