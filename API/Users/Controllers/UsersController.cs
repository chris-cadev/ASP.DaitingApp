using Microsoft.AspNetCore.Mvc;
using API.Common.Controllers;
using API.Users.DTOs;
using Microsoft.AspNetCore.Authorization;
using API.Accounts.Interfaces;

namespace API.Users.Controllers;

public class UsersController(IUserRepository repository) : BaseApiController
{
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await repository.GetUsersAsync();
        if (!users.Any())
        {
            return NotFound();
        }
        return Ok(users);
    }

    [Authorize]
    [HttpGet("{username}")]
    public async Task<ActionResult<UserDto>> GetUser(string username)
    {
        var user = await repository.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();

        return Ok(user);
    }

}
