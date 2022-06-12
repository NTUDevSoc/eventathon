using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSoc.Eventathon.Data;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(options =>
        {
            options.ConnectionString = configuration.GetConnectionString(Databases.Eventathon);
        });
        
        return services.AddTransient<IConnectionManager, PostgresSQLConnectionManager>();
    }
}