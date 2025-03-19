using System;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Extensions;

public static class DataExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
        return services;
    }

}
