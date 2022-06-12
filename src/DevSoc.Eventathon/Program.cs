using DevSoc.Eventathon.Calendars;
using DevSoc.Eventathon.Data;

namespace DevSoc.Eventathon;

internal class Program
{
    internal static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.Configure<DatabaseOptions>(options =>
        {
            options.ConnectionString = builder.Configuration.GetConnectionString(Databases.Eventathon);
        });
        
        builder.Services.AddCalDAVClient(builder.Configuration);
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        
        app.Run();
    }
}
