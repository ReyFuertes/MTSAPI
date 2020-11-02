using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MTS.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
