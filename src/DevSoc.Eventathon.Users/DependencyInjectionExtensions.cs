using Microsoft.Extensions.DependencyInjection;

namespace DevSoc.Eventathon.Data;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddUsers(this IServiceCollection services)
    {
        return services.AddTransient<IConnectionManager, PostgresSQLConnectionManager>();
    }
}