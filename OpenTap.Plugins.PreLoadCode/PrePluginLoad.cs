using System;
using OpenTap.Plugins.PreLoadCode.Settings;

namespace OpenTap.Plugins.PreLoadCode
{
    /// <summary>
    /// Class containing pre-plugin load method
    /// This class and method both must be public and static
    /// </summary>
    public static class PrePluginLoad
    {
        internal static string LogSourceName => "PreLoadCode";

        internal static string PreLoadMessage => "Running before plugin is loaded!";

        internal static string PluginLoadExceptionMessage => "Set to not load plugin";

        private static TraceSource _logSource;
        private static TraceSource LogSource => _logSource ??= Log.CreateSource(LogSourceName);

        /// <summary>
        /// Set by <see cref="PluginAssemblyAttribute"/> to be run first before any other plugin code is run or types are loaded
        /// If this method throws an exception, then the plugin won't be loaded
        /// </summary>
        public static void RunBeforePluginLoad()
        {
            Log.Info(LogSource, PreLoadMessage);
            if (!PluginSettings.CurrentSettings.ShouldLoadPlugin)
                throw new PrePluginLoadException(PluginLoadExceptionMessage);
        }
    }

    public class PrePluginLoadException : Exception
    {
        public PrePluginLoadException(string message) : base(message) { }
    }
}
