using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace GenericHostHostingChanges
{
    /// <summary>
    /// This should go into <see cref="Microsoft.Extensions.Hosting.HostOptions"/>
    /// </summary>
    public class HostingStartupOptions
    {
        public HostingStartupOptions(HostBuilderContext hostContext)
        {
            if (hostContext == null)
            {
                throw new ArgumentNullException(nameof(hostContext));
            }


            // Search the primary assembly and configured assemblies.
            HostingStartupAssemblies =
                Split(
                    $"{hostContext.HostingEnvironment.ApplicationName};{hostContext.Configuration[HostDefaults.HostingStartupAssembliesKey]}");
            HostingStartupExcludeAssemblies =
                Split(hostContext.Configuration[HostDefaults.HostingStartupExcludeAssembliesKey]);
        }


        public IReadOnlyList<string> HostingStartupExcludeAssemblies { get; set; }

        public IReadOnlyList<string> HostingStartupAssemblies { get; set; }

        private static IReadOnlyList<string> Split(string value)
        {
            return value?.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                   ?? Array.Empty<string>();
        }

        public IEnumerable<string> GetFinalHostingStartupAssemblies()
        {
            return HostingStartupAssemblies.Except(HostingStartupExcludeAssemblies, StringComparer.OrdinalIgnoreCase);
        }
    }
}