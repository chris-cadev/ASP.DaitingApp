using System;

namespace API.Users.DTOs;

public class PhotoDto
{
    public int Id { get; set; }
    public string? Url { get; set; }
    public required bool IsMain { get; set; } = false;

}
