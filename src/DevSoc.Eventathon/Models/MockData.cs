using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Models;

public class MockData
{
    private EventRestResponse singleEvent;
    private EventListRestResponse multipleEvents;

    public MockData()
    {
        singleEvent = new EventRestResponse
        {
            singleEvent = new EventResponse
            {
                Id = 2,
                Title = "Single mock event",
                Description = "This is a singular mock event",
                Start = DateTime.UtcNow.AddDays(-5),
                End = DateTime.UtcNow.AddDays(-4)
            }
        };


        multipleEvents = new EventListRestResponse
        {
            eventList = new EventResponse[]
            {
                new EventResponse
                {
                    Id = 1,
                    Title = "Mock event 1",
                    Description = "This is a mock event",
                    Start = DateTime.UtcNow.AddDays(-2),
                    End = DateTime.UtcNow.AddDays(-1)
                },
                new EventResponse
                {
                    Id = 2,
                    Title = "Mock event 2",
                    Description = "This is a mock event",
                    Start = DateTime.UtcNow.AddDays(-1),
                    End = DateTime.UtcNow
                },
                new EventResponse
                {
                    Id = 3,
                    Title = "Mock event 3",
                    Description = "This is a mock event",
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow.AddHours(3)
                },
                new EventResponse
                {
                    Id = 4,
                    Title = "Mock event 4",
                    Description = "This is a mock event",
                    Start = DateTime.UtcNow.AddDays(2),
                    End = DateTime.UtcNow.AddDays(3).AddHours(-4)
                },
                new EventResponse
                {
                    Id = 5,
                    Title = "Mock event 5",
                    Description = "This is a mock event",
                    Start = DateTime.UtcNow.AddDays(10),
                    End = DateTime.UtcNow.AddMonths(1)
                }
            }
        };
    }

    public EventRestResponse getSingleEvent()
    {
        return singleEvent;
    }

    public EventListRestResponse getMultipleEvents()
    {
        return multipleEvents;
    }
}