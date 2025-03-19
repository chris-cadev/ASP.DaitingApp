using System;

namespace API.App.Extensions;

public static class AppExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddCors();
        return services;
    }

}
