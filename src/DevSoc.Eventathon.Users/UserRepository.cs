using Dapper.Contrib.Extensions;
using DevSoc.Eventathon.Data.Models;
using DevSoc.Eventathon.Data.Security.Encryption;

namespace DevSoc.Eventathon.Data;

public class UserRepository : IUsersRepository
{
    private readonly IConnectionManager _connectionManager;

    public UserRepository(IConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }
    
    public Task<User?> GetUser(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateUser(User user)
    {
        using var connection = await _connectionManager.Open();
        using var transaction = connection.BeginTransaction();

        await connection.InsertAsync(user);
        return user.Id;
    }
    
    public async Task<HashedPasswordResult?> GetHashedPasswordForUser(string username)
    {
        var user = await GetUser(username);
        if (user is null)
        {
            return null;
        }
            
        return new HashedPasswordResult
        {
            HashedPassword = user.HashedPassword,
            Base64SaltUsed = user.Salt
        };
    }
}