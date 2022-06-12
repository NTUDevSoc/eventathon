using System.ComponentModel.DataAnnotations.Schema;

namespace DevSoc.Eventathon.Data.Models;

[Table("public.users")]
public class User
{
    [Column("Id")]
    public string Id { get; set; }
    
    [Column("Username")]
    public string Username { get; set; }
    
    [Column("HashedPassword")]
    public string HashedPassword { get; set; }
    
    [Column("Salt")]
    public string Salt { get; set; }
}