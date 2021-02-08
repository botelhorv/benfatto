using BenFatto.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace BenFatto.Tests.Drivers
{
    public static class SetupServer
    {
        public static TestServer Setup()
        {
            var webHost = new WebHostBuilder().UseStartup<Startup>();

            var configurations = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            webHost.UseConfiguration(configurations);

            return new TestServer(webHost);
        }
    }
}
