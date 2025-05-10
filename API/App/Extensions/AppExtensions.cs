using System;
using API.Accounts.Interfaces;
using API.Users.Repositories;

namespace API.App.Extensions;

public static class AppExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddCors();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }

}
