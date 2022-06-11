using CalDAV.NET.Interfaces;
using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Calendars;

public interface IEventsRepository
{
    Task<List<ICalendar>> GetCalendars();
    Task<string> CreateEvent(EventDefinition definition);
}