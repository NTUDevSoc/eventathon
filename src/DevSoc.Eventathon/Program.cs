using DevSoc.Eventathon.Calendars;
using DevSoc.Eventathon.Data;

namespace DevSoc.Eventathon;

internal class Program
{
    internal static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        
        builder.Services
            .AddDatabase(builder.Configuration)
            .AddUsers(builder.Configuration)
            .AddEvents(builder.Configuration);
        
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }
        
        if (builder.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        await DatabaseMigrations.Run(app.Configuration.GetConnectionString(Databases.Eventathon));

        app.UseHttpsRedirection();
        app.UseAuthorization();
        
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.MapControllerRoute("API controllers", "api/*");
        app.MapFallbackToFile("index.html");
        
        await app.RunAsync();
    }
}
