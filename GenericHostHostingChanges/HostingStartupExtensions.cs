using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenericHostHostingChanges
{
    public static class HostingStartupExtensions
    {
        public static HostBuilderContext AddHostingStartupAssemblies(this HostBuilderContext hostBuilder, IServiceCollection services)
        {
            
            var hostOptions = new HostingStartupOptions(hostBuilder);
            var exceptions = new List<Exception>();
            var processed = new HashSet<Assembly>();
            var options = hostBuilder.Properties;
            // Execute the hosting startup assemblies
            foreach (var assemblyName in hostOptions.GetFinalHostingStartupAssemblies())
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(assemblyName));

                    if (!processed.Add(assembly))
                    {
                        // Already processed, skip it
                        continue;
                    }

                    foreach (var attribute in assembly.GetCustomAttributes<HostingStartupAttribute>())
                    {
                        var hostingStartup = (IHostingStartup) Activator.CreateInstance(attribute.HostingStartupType)!;
                        hostingStartup.Configure(hostBuilder, services);
                    }
                }
                catch (Exception ex)
                {
                    // Capture any errors that happen during startup
                    exceptions.Add(new InvalidOperationException(
                        $"Startup assembly {assemblyName} failed to execute. See the inner exception for more details.",
                        ex));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

            return hostBuilder;
        }
    }
}