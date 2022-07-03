namespace DevSoc.Eventathon.Data.Security.Encryption;

public class HashedPasswordResult
{
    public string Base64SaltUsed { get; set; } = "";
    public string HashedPassword { get; set; } = "";
}
