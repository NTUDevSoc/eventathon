using DevSoc.Eventathon.Data.Models;
using DevSoc.Eventathon.Data.Security.Encryption;

namespace DevSoc.Eventathon.Data;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UsersService(IUsersRepository usersRepository, IPasswordHasher passwordHasher)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> CreateUser(UserDefinition definition)
    {
        var hashedPasswordResult = _passwordHasher.HashPassword(definition.Password);
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = definition.Username,
            HashedPassword = hashedPasswordResult.HashedPassword,
            Salt = hashedPasswordResult.Base64SaltUsed
        };

        return await _usersRepository.CreateUser(user);
    }
}