using System;
using API.Accounts.Entities;
using API.Users.DTOs;

namespace API.Accounts.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetAppUsersAsync();
    Task<AppUser?> GetAppUserByIdAsync(int id);
    Task<AppUser?> GetAppUserByUsernameAsync(string username);
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto?> GetUserByUsernameAsync(string username);
}
