using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MTS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileManager, FileManagerService>();

            return services;
        }
    }
}
