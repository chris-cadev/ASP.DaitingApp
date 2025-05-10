using System;
using API.Accounts.Entities;
using API.Accounts.Interfaces;
using API.Data;
using API.Users.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Users.Repositories;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
    public async Task<IEnumerable<AppUser>> GetAppUsersAsync()
    {
        return await context.Users
        .Include(x => x.Photos)
        .ToListAsync();
    }

    public async Task<AppUser?> GetAppUserByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<AppUser?> GetAppUserByUsernameAsync(string username)
    {
        return await context.Users
        .Include(x => x.Photos)
        .SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(AppUser user)
    {
        context.Entry(user).State = EntityState.Modified;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        return await context.Users
        .Where(u => u.Deleted == null)
        .ProjectTo<UserDto>(mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<UserDto?> GetUserByUsernameAsync(string username)
    {
        return await context.Users
        .Include(x => x.Photos)
        .Where(u => u.UserName == username)
        .ProjectTo<UserDto>(mapper.ConfigurationProvider)
        .SingleOrDefaultAsync();
    }
}
