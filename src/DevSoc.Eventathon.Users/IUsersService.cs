using DevSoc.Eventathon.Data.Models;

namespace DevSoc.Eventathon.Data;

public interface IUsersService
{
    Task<string> CreateUser(UserDefinition definition);
}