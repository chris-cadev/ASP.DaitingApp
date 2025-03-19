using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Common.Controllers;
using API.Users.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Users.Controllers;

public class UsersController(DataContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        if (users.Count == 0)
        {
            return NotFound();
        }
        var response = users.Select(u => new UserDto { Username = u.UserName }).ToList();
        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(new UserDto
        {
            Username = user.UserName
        });
    }

}
