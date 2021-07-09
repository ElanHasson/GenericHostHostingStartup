using GenericHostHostingChanges;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SomeModuleToLoadAtStartup;

[assembly: HostingStartup(typeof(SomethingToStartUp))]

namespace SomeModuleToLoadAtStartup
{
    public class SomethingToStartUp : IHostingStartup
    {
        public void Configure(HostBuilderContext builder, IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<MyInjectedWorker>();
        }
    }
}