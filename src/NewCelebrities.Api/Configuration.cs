using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using NewCelebrities.Shared;

namespace NewCelebrities.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IWebHostEnvironment environment,
            IConfiguration configuration)
        {
            return services
                .AddHttpContextAccessor()
                .AddCors()
                .AddControllersFromOtherAssemblies()
                .AddProblemDetails(environment, configuration)
                .AddCustomApiBehaviour()
                .AddCustomServices(environment);
        }

        public static IApplicationBuilder Configure(IApplicationBuilder app, Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
            return configureHost(app)
                .UseProblemDetails()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
 
}
