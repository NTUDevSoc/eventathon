using System.Data;

namespace DevSoc.Eventathon.Data;

public interface IConnectionManager
{
    Task<IDbConnection> Open();
}