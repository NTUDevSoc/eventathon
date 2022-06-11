namespace DevSoc.Eventathon.Data;

public class EventsRepository
{
    private readonly IConnectionManager _connectionManager;

    public EventsRepository(IConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    public async Task Insert()
    {
        
    }
}