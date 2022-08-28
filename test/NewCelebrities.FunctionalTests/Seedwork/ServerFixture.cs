using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.IO;
using System.Linq;

namespace NewCelebrities.FunctionalTests
{
    public class ServerFixture
    {
        public T GetService<T>() => Server.Services.GetService<T>();

        public TestServer Server { get; private set; }

        public ServerFixture()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();

            var host = new HostBuilder()
              .ConfigureWebHost(webBuilder =>
              {
                  webBuilder
                    .UseTestServer()
                    .UseSerilog()
                    .UseStartup<TestStartup>()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration(app =>
                    {
                        app.AddJsonFile("appsettings.json", optional: true);
                        app.AddUserSecrets(typeof(ServerFixture).Assembly, optional: true);
                        app.AddEnvironmentVariables();
                    });
              })
              .Start();

            Server = host.GetTestServer();
            //Configuration = Server.Services.GetService<IConfiguration>();

        }

    }
}
