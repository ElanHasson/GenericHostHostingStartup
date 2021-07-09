using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenericHostHostingChanges
{
    /// <summary>
    /// Represents platform specific configuration that will be applied to a <see cref="IHostBuilder"/> when building an <see cref="IHost"/>.
    /// </summary>
    public interface IHostingStartup
    {
        /// <summary>
        /// Configure the <see cref="IHostBuilder"/>.
        /// </summary>
        /// <remarks>
        /// Configure is intended to be called before user code, allowing a user to overwrite any changes made.
        /// </remarks>
        /// <param name="builder"></param>
        /// <param name="serviceCollection"></param>
        void Configure(HostBuilderContext builder, IServiceCollection serviceCollection);
    }
}