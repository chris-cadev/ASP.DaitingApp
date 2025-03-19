namespace API.Accounts.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }

    public DateTime? DeletedAt { get; set; }

    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
}
