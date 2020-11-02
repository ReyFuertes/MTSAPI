using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MTSDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("MTSDatabase")));

            return services;
        }
    }
}
