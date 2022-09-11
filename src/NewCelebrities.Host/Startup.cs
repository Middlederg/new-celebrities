using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Host
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Api.Configuration.ConfigureServices(services, environment, Configuration)
                .AddSwaggerGen(c =>
                 {
                     c.SwaggerDoc("v1", new OpenApiInfo
                     {
                         Title = "Celebrity Api",
                         Version = "v1",
                         Description = "Api con personajes famosos",
                         Contact = new OpenApiContact
                         {
                             Name = "jcl",
                             Url = new Uri("https://github.com/jcl86"),
                         }
                     });
                 });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Celebrity Api v1"));
            }

            var allowedOrigins = Configuration.GetSection("AllowedOrigins").Get<IEnumerable<string>>();
            Api.Configuration.Configure(app, host =>
            {
                return host
                    .UseCors(policy =>
                     policy.WithOrigins(allowedOrigins.ToArray())
                     .AllowAnyMethod()
                     .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
                     .AllowCredentials())
                    .UseDefaultFiles()
                    .UseStaticFiles();
            });
        }
    }
}
