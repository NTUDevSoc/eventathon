using Dapper;
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
    
    public async Task<List<User>> GetUser(string id)
    {
        // throw new NotImplementedException();
        using var connection = await _connectionManager.Open();
        var queryString = "SELECT * FROM public.users WHERE users.username = @idSql";
        using (connection)
        {
            return connection.Query<User>(queryString, new { idSql = id}).ToList();
        }
    }

    public async Task<string> CreateUser(User user)
    {
        using var connection = await _connectionManager.Open();
        using var transaction = connection.BeginTransaction();

        var insertQuery = @"
        INSERT INTO public.users
        (""id"", ""username"", ""hashedPassword"", ""salt"")
        VALUES(@id, @username, @hashedPassword, @salt);";

        await connection.ExecuteAsync(insertQuery, user);
        transaction.Commit();

        return user.Id;
    }
    
    public async Task<HashedPasswordResult?> GetHashedPasswordForUser(string username)
    {
        var userList = await GetUser(username);
        if (userList is null)
        {
            return null;
        }

        var user = userList[0];    
        return new HashedPasswordResult
        {
            HashedPassword = user.HashedPassword,
            Base64SaltUsed = user.Salt
        };
    }
}