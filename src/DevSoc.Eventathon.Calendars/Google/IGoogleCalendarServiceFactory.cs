using Google.Apis.Calendar.v3;

namespace DevSoc.Eventathon.Calendars.Google;

public interface IGoogleCalendarServiceFactory
{
    CalendarService Create();
}