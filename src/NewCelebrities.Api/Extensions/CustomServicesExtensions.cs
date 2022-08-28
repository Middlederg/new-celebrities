using System.Net.Http;
using System;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IHostEnvironment environment)
        {
            //services.AddScoped<TokenGenerator>();
            return services;
        }
    }
}
