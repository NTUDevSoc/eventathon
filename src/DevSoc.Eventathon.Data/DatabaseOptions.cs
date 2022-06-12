namespace DevSoc.Eventathon.Data;

public class DatabaseOptions
{
    public static string AppSettingsSection => "Security";
    public string ConnectionString { get; set; } = "";
}