using Xunit;
using OpenTap.Plugins.PreLoadCode.Settings;
using System.IO;

namespace OpenTap.Plugins.PreLoadCode.Test
{
    public class PluginSettingsTest
    {
        private readonly PluginSettings _pluginSettings;

        private readonly string _pluginSettingsTestFileName = "pluginSettingsTestFile.json";

        public PluginSettingsTest()
        {
            _pluginSettings = new()
            {
                ShouldLoadPlugin = false,
            };
        }

        [Fact]
        public void PluginSettingsSavesLoads()
        {
            PluginSettingsIO.SavePluginSettings(_pluginSettings, _pluginSettingsTestFileName);
            PluginSettings loadedSettings = PluginSettingsIO.LoadPluginSettings(_pluginSettingsTestFileName);
            Assert.Equal(_pluginSettings.ShouldLoadPlugin, loadedSettings.ShouldLoadPlugin);
            File.Delete(_pluginSettingsTestFileName);
        }

        [Fact]
        public void PluginSettingsEqualsOperatorMatches()
        {
            PluginSettings pluginSettings1 = new() 
            { 
               ShouldLoadPlugin = true
            };
            PluginSettings pluginSettings2 = new()
            { 
               ShouldLoadPlugin = true
            };

            Assert.Equal(pluginSettings1, pluginSettings2);
        }

        [Fact]
        public void PluginSettingsNotEqualOperatorDontMatch()
        {
            PluginSettings pluginSettings1 = new()
            { 
               ShouldLoadPlugin = true
            };
            PluginSettings pluginSettings2 = new()
            {
                ShouldLoadPlugin = false
            };

            Assert.NotEqual(pluginSettings1, pluginSettings2);
        }
    }
}
