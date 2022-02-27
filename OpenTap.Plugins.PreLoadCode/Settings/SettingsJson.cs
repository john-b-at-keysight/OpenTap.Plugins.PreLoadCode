using System.IO;
using Newtonsoft.Json;

namespace OpenTap.Plugins.PreLoadCode.Settings
{
    internal static class SettingsJson
    {
        private static string LocalSettingsJsonFileName => "preLoadCodePluginSettings.json";

        public static PluginSettings LoadPluginSettings()
        {
            string jsonText = File.ReadAllText(LocalSettingsJsonFileName);
            PluginSettings settings = JsonConvert.DeserializeObject<PluginSettings>(jsonText);
            return settings;
        }

        public static void SavePluginSettings(PluginSettings settings)
        {
            string jsonText = JsonConvert.SerializeObject(settings);
            File.WriteAllText(LocalSettingsJsonFileName, jsonText);
        }
    }
}
