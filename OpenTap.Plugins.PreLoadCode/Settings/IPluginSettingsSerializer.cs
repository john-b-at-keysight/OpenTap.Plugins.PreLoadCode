using System;

namespace OpenTap.Plugins.PreLoadCode.Settings
{
    internal interface IPluginSettingsSerializer
    {
        public string FileExtension { get; }

        public string Serialize(PluginSettings settings);

        public PluginSettings Deserialize(string serializedText);
    }

    internal static class PluginSettingsSerializerFactory
    {
        public static IPluginSettingsSerializer GetPluginSettingsSerializer()
        {
            return new PluginSettingsJsonSerializer();
        }
    }

    internal class PluginSettingsSerializationException : Exception
    {
        public PluginSettingsSerializationException() : base() { }

        public PluginSettingsSerializationException(string message) : base(message) { }

        public PluginSettingsSerializationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
