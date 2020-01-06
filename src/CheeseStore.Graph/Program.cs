using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CheeseStore.Graph
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            return CreateWebHostBuilder(args).Build().RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => config.AddEnvironmentVariables("CheeseStore:Graph:"))
                .ConfigureServices(
                    (hostContext, services) =>
                    {
                        services.AddOptions<Store.Configuration>().Bind(hostContext.Configuration.GetSection("Store"));
                        services.AddOptions<Inventory.Configuration>().Bind(hostContext.Configuration.GetSection("Inventory"));
                    })
                .UseStartup<Startup>();
        }
    }
}
