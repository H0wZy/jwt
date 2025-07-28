using jwt.Enum;

namespace jwt.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public byte[] HashPassword { get; set; }
    public byte[] SaltPassword { get; set; }
    public Cargo Cargo { get; set; }
    public DateTime TokenCreatedAt { get; set; } = DateTime.UtcNow;
}