namespace API.Users.DTOs;

public class UserDto
{
    public required int Id { get; set; }
    public required string Username { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }

    public string? PhotoUrl { get; set; }

    public required string KnownAs { get; set; }

    public string? Gender { get; set; }

    public string? Introduction { get; set; }
    public string? LookingFor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public List<PhotoDto> Photos { get; set; } = [];
}
