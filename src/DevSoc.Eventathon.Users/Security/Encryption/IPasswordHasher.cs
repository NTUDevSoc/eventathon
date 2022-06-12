using DevSoc.Eventathon.Data.Encryption;

namespace DevSoc.Eventathon.Data.Security.Encryption;

public interface IPasswordHasher
{
    HashedPasswordResult HashPassword(string password);
    VerifyPasswordResult VerifyPassword(string hashedPassword, string base64SaltForHash, string providedPassword);
}