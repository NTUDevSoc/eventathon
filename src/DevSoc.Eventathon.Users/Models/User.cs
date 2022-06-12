namespace DevSoc.Eventathon.Data.Models;

public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string Salt { get; set; }
}