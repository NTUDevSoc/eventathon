using DevSoc.Eventathon.Data.Models;
using DevSoc.Eventathon.Data.Security.Encryption;

namespace DevSoc.Eventathon.Data;

public interface IUsersRepository
{
    Task<List<User>> GetUser(string id);
    Task<string> CreateUser(User user);
    Task<HashedPasswordResult?> GetHashedPasswordForUser(string username);
}