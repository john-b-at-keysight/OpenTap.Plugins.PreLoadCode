using System.IO;

namespace OpenTap.Plugins.PreLoadCode.Settings
{
    internal static class PluginSettingsIO
    {
        internal static string PluginSettingsFileName => 
            $"preLoadCodePluginSettings{PluginSettingsSerializer.FileExtension}";

        private static IPluginSettingsSerializer _pluginSettingsSerializer;
        private static IPluginSettingsSerializer PluginSettingsSerializer => 
            _pluginSettingsSerializer ??= PluginSettingsSerializerFactory.GetPluginSettingsSerializer();

        public static PluginSettings LoadPluginSettings()
        {
            return LoadPluginSettings(PluginSettingsFileName);
        }

        internal static PluginSettings LoadPluginSettings(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            PluginSettings settings = PluginSettingsSerializer.Deserialize(fileText);
            return settings;
        }

        public static void SavePluginSettings(PluginSettings settings)
        {
            SavePluginSettings(settings, PluginSettingsFileName);
        }

        internal static void SavePluginSettings(PluginSettings settings, string filePath)
        {
            string fileText = PluginSettingsSerializer.Serialize(settings);
            File.WriteAllText(filePath, fileText);
        }
    }
}
