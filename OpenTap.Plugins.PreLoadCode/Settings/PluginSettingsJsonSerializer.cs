using Newtonsoft.Json;

namespace OpenTap.Plugins.PreLoadCode.Settings
{
    internal class PluginSettingsJsonSerializer : IPluginSettingsSerializer
    {
        public string FileExtension => ".json";

        public PluginSettings Deserialize(string serializedText)
        {
            try
            {
                PluginSettings settings = JsonConvert.DeserializeObject<PluginSettings>(serializedText);
                return settings;
            }
            catch (JsonSerializationException exc)
            {
                throw new PluginSettingsSerializationException("Error while deserializing settings", exc);
            }
        }

        public string Serialize(PluginSettings settings)
        {
            try
            {
                string jsonText = JsonConvert.SerializeObject(settings);
                return jsonText;
            }
            catch (JsonSerializationException exc)
            {
                throw new PluginSettingsSerializationException("Error while serializing settings", exc);
            }
        }
    }
}
