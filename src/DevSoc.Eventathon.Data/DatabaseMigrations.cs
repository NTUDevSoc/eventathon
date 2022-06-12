using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using DbUp;

namespace DevSoc.Eventathon.Data;

public static class DatabaseMigrations
{
    public static async Task Run(string connectionString)
    {
        var migrator = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

        var result = migrator.PerformUpgrade();
        if (!result.Successful)
        {
            await Console.Error.WriteLineAsync($"Failed to migrate database: {result.Error.Message}");
        }
        
        Console.WriteLine("Database successfully migrated");
    }
}