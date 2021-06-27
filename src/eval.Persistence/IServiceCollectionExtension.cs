﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eval.Persistence
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TempContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TempConnection"));
            });
            return services;
        }
    }
}
