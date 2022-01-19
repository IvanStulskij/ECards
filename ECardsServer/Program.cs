using ECardsLibFramework.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ServiceModel;

namespace ECardsServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var host = new ServiceHost(nameof(ServiceCards)))
            {
                //host.Open();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
