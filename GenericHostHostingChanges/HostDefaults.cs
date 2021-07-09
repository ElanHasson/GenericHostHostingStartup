namespace GenericHostHostingChanges
{
    /// <summary>
    /// Should be <see cref="Microsoft.Extensions.Hosting.HostDefaults"/>.
    /// </summary>
    public static class HostDefaults
    {
        /// <summary>
        /// The configuration key associated with "hostingStartupAssemblies" configuration.
        /// </summary>
        public static readonly string HostingStartupAssembliesKey = "hostingStartupAssemblies";

        /// <summary>
        /// The configuration key associated with the "hostingStartupExcludeAssemblies" configuration.
        /// </summary>
        public static readonly string HostingStartupExcludeAssembliesKey = "hostingStartupExcludeAssemblies";
    }
}