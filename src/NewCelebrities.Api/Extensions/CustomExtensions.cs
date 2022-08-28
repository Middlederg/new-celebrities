using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Builder;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomExtensions
    {
        public static IServiceCollection AddControllersFromOtherAssemblies(this IServiceCollection services) =>
            services
                .AddControllers()
                .AddApplicationPart(typeof(CustomExtensions).Assembly)
                .Services;
    }
}
