﻿using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Calendars;

public interface IEventsRepository
{
    Task<EventResponse> GetEvent(string id);
    Task<EventResponse[]> GetEvents();
    Task<string> CreateEvent(EventDefinition definition);
    Task<bool> DeleteEvent(string uid);
    Task<string> EditEvent(string uid, EventDefinition newDefinition);
}