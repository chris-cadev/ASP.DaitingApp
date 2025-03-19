using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using API.Common.Controllers;
using API.Data;
using API.Accounts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Accounts.Entities;
using API.Accounts.Interfaces;
using API.Users.DTOs;

namespace API.Accounts.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<UserAuthorizedDto>> Register(RegisterDto dto)
    {
        if (await UserExists(dto.Username)) return BadRequest(new { message = "Username has taken" });
        using var hmac = new HMACSHA512();


        var user = new AppUser
        {
            UserName = dto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();
        return new UserAuthorizedDto
        {
            Username = user.UserName,
            Token = tokenService.CrateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserAuthorizedDto>> Login(LoginDto dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(UsernameFilter(dto.Username));
        if (user == null) return Unauthorized(new { message = "Not registered" });

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
                return Unauthorized(new { message = "invalid credentials" });
        }
        return new UserAuthorizedDto
        {
            Username = user.UserName,
            Token = tokenService.CrateToken(user)
        };
    }

    private static Expression<Func<AppUser, bool>> UsernameFilter(string username)
    {
        username = username.ToLower(); // Normalize input once
        return user => user.UserName.ToLower() == username;
    }

    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(UsernameFilter(username));
    }


}
