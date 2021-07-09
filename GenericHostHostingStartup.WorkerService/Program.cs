using Microsoft.Extensions.Hosting;
using GenericHostHostingChanges;

namespace GenericHostHostingStartup.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    hostContext.AddHostingStartupAssemblies(services);
                });
    }
}
