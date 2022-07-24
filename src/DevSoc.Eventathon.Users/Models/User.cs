using System.ComponentModel.DataAnnotations.Schema;

namespace DevSoc.Eventathon.Data.Models;

[Table("public.users")]
public class User
{
    [Column("id")]
    public string Id { get; set; } = "";
    
    [Column("username")]
    public string Username { get; set; } = "";
    
    [Column("hashedPassword")]
    public string HashedPassword { get; set; } = "";
    
    [Column("salt")]
    public string Salt { get; set; } = "";
}