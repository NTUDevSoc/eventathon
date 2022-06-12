using DevSoc.Eventathon.Calendars.Models;

namespace DevSoc.Eventathon.Controllers;

public class MockData
{
    private EventDefinition singleEvent;
    private EventDefinition[] multipleEvents;

    public MockData()
    {
        singleEvent = new EventDefinition
        {
            Name = "Single mock event",
            Description = "This is a singular mock event",
            Start = DateTime.UtcNow.AddDays(-5),
            End = DateTime.UtcNow.AddDays(-4)
        };

        multipleEvents = new EventDefinition[]
        {
            new EventDefinition
            {
                Name = "Mock event 1",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(-5),
                End = DateTime.UtcNow.AddDays(-4)
            },
            new EventDefinition
            {
                Name = "Mock event 2",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(-3),
                End = DateTime.UtcNow.AddDays(-1)
            },
            new EventDefinition
            {
                Name = "Mock event 3",
                Description = "This is a mock event",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(5)
            },
            new EventDefinition
            {
                Name = "Mock event 4",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(2),
                End = DateTime.UtcNow.AddDays(3)
            },
            new EventDefinition
            {
                Name = "Mock event 5",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(10),
                End = DateTime.UtcNow.AddMonths(1)
            }
        };
    }

    public EventDefinition getSingleEvent()
    {
        return singleEvent;
    }

    public EventDefinition[] getMultipleEvents()
    {
        return multipleEvents;
    }
}