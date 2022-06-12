namespace DevSoc.Eventathon.Data.Security;

public class SecurityOptions
{
    public static string AppSettingsSection => "Security";
    public string Secret { get; set; }
    public TimeSpan JwtExpiry { get; set; }
}