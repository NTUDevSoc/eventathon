using ArgumentNullException = System.ArgumentNullException;

namespace DevSoc.Eventathon.Calendars.Google;

public class GoogleCalendarAuthenticationOptions
{
    public static string AppSettingsSection => "Google:Authentication";
    
    public string? ApplicationName { get; set; }

    public string? ImpersonateUser { get; set; }

    public GoogleCredentialSettings? Credentials { get; set; }

    public void ThrowIfInvalid()
    {
        ArgumentNullException.ThrowIfNull(ApplicationName);
        ArgumentNullException.ThrowIfNull(ImpersonateUser);
        ArgumentNullException.ThrowIfNull(Credentials);

        if (!Credentials.AreValid)
        {
            throw new ArgumentException($"{nameof(Credentials)} are invalid - maybe you forgot to fill in some of the secrets?");
        }
    }
}