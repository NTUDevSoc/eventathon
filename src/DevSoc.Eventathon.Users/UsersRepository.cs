using Dapper;
using Dapper.Contrib.Extensions;
using DevSoc.Eventathon.Data.Models;
using DevSoc.Eventathon.Data.Security.Encryption;

namespace DevSoc.Eventathon.Data;

public class UsersRepository : IUsersRepository
{
    private readonly IConnectionManager _connectionManager;

    public UsersRepository(IConnectionManager connectionManager)
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

        var insertQuery = @"
        INSERT INTO public.users
        (""Id"", ""Username"", ""HashedPassword"", ""Salt"")
        VALUES(@id, @username, @hashedPassword, @salt);";

        await connection.ExecuteAsync(insertQuery, user);
        transaction.Commit();
        
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