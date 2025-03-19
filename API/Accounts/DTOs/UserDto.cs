using System;

namespace API.Users.DTOs;

public class UserAuthorizedDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
