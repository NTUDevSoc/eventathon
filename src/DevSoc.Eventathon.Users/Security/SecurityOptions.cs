using System.Diagnostics.CodeAnalysis;

namespace DevSoc.Eventathon.Data.Security;

public class SecurityOptions
{
    public static string AppSettingsSection => "Security";
    
    public string? Secret { get; set; }
    public TimeSpan? JwtExpiry { get; set; }

    [MemberNotNullWhen(true, nameof(Secret))]
    [MemberNotNullWhen(true, nameof(JwtExpiry))]
    public bool IsValid() => !string.IsNullOrEmpty(Secret) && JwtExpiry.HasValue;
}