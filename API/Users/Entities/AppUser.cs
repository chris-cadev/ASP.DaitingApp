namespace API.Accounts.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using API.Accounts.Extensions;

[Table("Users")]
public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }


    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public DateOnly DateOfBirth { get; set; }

    public required string Gender { get; set; }

    public required string KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public string? Introduction { get; set; }
    public string? LookingFor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public List<Photo> Photos { get; set; } = [];
    public DateTime? Deleted { get; set; }

    // public int GetAge()
    // {
    //     return DateOfBirth.CalculateAge();
    // }
}
