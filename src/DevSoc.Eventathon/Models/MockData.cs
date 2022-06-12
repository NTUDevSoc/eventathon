using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Models;

public class MockData
{

    public MockData()
    {
    }

    public EventRestResponse getSingleEvent()
    {
        return new EventRestResponse
        {
            @event = new EventResponse
            {
                id = 2,
                title = "Single mock event",
                description = "This is a singular mock event",
                start = DateTime.UtcNow.AddDays(-5),
                end = DateTime.UtcNow.AddDays(-4)
            }
        };
    }

    public EventListRestResponse getMultipleEvents()
    {
        return new EventListRestResponse 
        {
            events = new EventResponse[]
            {
                new EventResponse
                {
                    id = 1,
                    title = "Mock event 1",
                    description = "This is a mock event",
                    start = DateTime.UtcNow.AddDays(-2),
                    end = DateTime.UtcNow.AddDays(-1)
                },
                new EventResponse
                {
                    id = 2,
                    title = "Mock event 2",
                    description = "This is a mock event",
                    start = DateTime.UtcNow.AddDays(-1),
                    end = DateTime.UtcNow
                },
                new EventResponse
                {
                    id = 3,
                    title = "Mock event 3",
                    description = "This is a mock event",
                    start = DateTime.UtcNow,
                    end = DateTime.UtcNow.AddHours(3)
                },
                new EventResponse
                {
                    id = 4,
                    title = "Mock event 4",
                    description = "This is a mock event",
                    start = DateTime.UtcNow.AddDays(2),
                    end = DateTime.UtcNow.AddDays(3).AddHours(-4)
                },
                new EventResponse
                {
                    id = 5,
                    title = "Mock event 5",
                    description = "This is a mock event",
                    start = DateTime.UtcNow.AddDays(10),
                    end = DateTime.UtcNow.AddMonths(1)
                }
            }
        };
    }
}