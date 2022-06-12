using DevSoc.Eventathon.Data.Security;
using DevSoc.Eventathon.Data.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSoc.Eventathon.Data;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddUsers(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<SecurityOptions>(configuration.GetSection(SecurityOptions.AppSettingsSection))
            .AddTransient<IPasswordHasher, Pbkdf2PasswordHasher>()
            .AddTransient<IUsersRepository, IUsersRepository>()
            .AddTransient<IUsersService, UsersService>()
            .AddTransient<IAuthenticationService, AuthenticationService>();
    }
}