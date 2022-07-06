using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevSoc.Eventathon.Data.Security.Encryption;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DevSoc.Eventathon.Data.Security;

public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _userRepository;
        private readonly SecurityOptions _securitySettings;

        public AuthenticationService(IOptions<SecurityOptions> securitySettings, IPasswordHasher passwordHasher, IUsersRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _securitySettings = securitySettings.Value;
            
            if (!_securitySettings.IsValid())
            {
                throw new InvalidOperationException($"{nameof(IOptions<SecurityOptions>)} security settings are invalid for {nameof(AuthenticationService)}");
            }
        }
        
        public async Task<AuthenticationResult> Authenticate(string username, string password)
        {
            var hashedPasswordResult = await _userRepository.GetHashedPasswordForUser(username);
            
            if (hashedPasswordResult is null)
                return AuthenticationResult.Failed();
            
            var passwordVerificationResult = _passwordHasher.VerifyPassword(hashedPasswordResult.HashedPassword, 
                hashedPasswordResult.Base64SaltUsed,
                password);

            return passwordVerificationResult switch
            {
                VerifyPasswordResult.Success => AuthenticationResult.Success(GenerateJwt(username)),
                VerifyPasswordResult.Failure => AuthenticationResult.Failed(),
                _ => throw new ArgumentOutOfRangeException($"Received unrecognised {nameof(VerifyPasswordResult)} from {nameof(_passwordHasher.VerifyPassword)}")
            };
        }
        
        private string GenerateJwt(string username)
        {
            if (!_securitySettings.IsValid())
            {
                throw new InvalidOperationException($"{nameof(IOptions<SecurityOptions>)} security settings are invalid for {nameof(AuthenticationService)}");
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_securitySettings.Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Email, username)
                }),
                Expires = DateTime.UtcNow.Add(_securitySettings.JwtExpiry.Value),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }