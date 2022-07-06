using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DevSoc.Eventathon.Data.Security.Encryption;

public class Pbkdf2PasswordHasher : IPasswordHasher
{
    private const int HashIterations = 10000;
    private const int SaltBytes = 16;
    private const int SubKeyBytes = 32;

    public HashedPasswordResult HashPassword(string password)
    {
        var salt = new byte[SaltBytes];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(salt);

        return new HashedPasswordResult
        {
            HashedPassword =  HashPasswordWithSalt(password, salt),
            Base64SaltUsed = Convert.ToBase64String(salt)
        };
    }
        
    public VerifyPasswordResult VerifyPassword(string hashedPassword, string base64SaltForHash, string providedPassword) =>
        HashPasswordWithSalt(providedPassword, Convert.FromBase64String(base64SaltForHash)) == hashedPassword
            ? VerifyPasswordResult.Success
            : VerifyPasswordResult.Failure;

    private static string HashPasswordWithSalt(string password, byte[] salt)
    {
        var subKey = KeyDerivation.Pbkdf2(
            password,
            salt,
            KeyDerivationPrf.HMACSHA1,
            HashIterations,
            SubKeyBytes);

        return Convert.ToBase64String(subKey);
    }
}