namespace DevSoc.Eventathon.Calendars.Models;

public class MockData
{

    public MockData()
    {
    }

    public Event GetSingleEvent()
    {
        return new Event
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Single mock event",
            Description = "This is a singular mock event",
            Start = DateTime.UtcNow.AddDays(-5),
            End = DateTime.UtcNow.AddDays(-4)
        };
    }

    public Event[] GetMultipleEvents()
    {
        return new[]
        { 
            new Event
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Mock event 1",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(-2),
                End = DateTime.UtcNow.AddDays(-1)
            },
            new Event
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Mock event 2",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(-1),
                End = DateTime.UtcNow
            },
            new Event
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Mock event 3",
                Description = "This is a mock event",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddHours(3)
            },
            new Event
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Mock event 4",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(2),
                End = DateTime.UtcNow.AddDays(3).AddHours(-4)
            },
            new Event
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Mock event 5",
                Description = "This is a mock event",
                Start = DateTime.UtcNow.AddDays(10),
                End = DateTime.UtcNow.AddMonths(1)
            }
        };
    }
 }