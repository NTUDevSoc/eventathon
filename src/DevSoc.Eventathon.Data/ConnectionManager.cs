using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace DevSoc.Eventathon.Data;

public class PostgresSQLConnectionManager : IConnectionManager
{
    private readonly IOptions<DatabaseOptions> _databaseOptions;

    public PostgresSQLConnectionManager(IOptions<DatabaseOptions> databaseOptions)
    {
        _databaseOptions = databaseOptions;
    }
    
    public async Task<IDbConnection> Open()
    {
        var connection = new NpgsqlConnection(_databaseOptions.Value.ConnectionString);
        await connection.OpenAsync();
        return connection;
    }
}