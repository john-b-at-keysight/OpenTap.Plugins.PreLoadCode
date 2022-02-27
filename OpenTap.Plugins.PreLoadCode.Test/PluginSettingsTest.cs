using Xunit;
using OpenTap.Plugins.PreLoadCode.Settings;

namespace OpenTap.Plugins.PreLoadCode.Test
{
    public class PluginSettingsTest
    {
        private readonly PluginSettings _pluginSettings;

        public PluginSettingsTest()
        {
            _pluginSettings = new()
            {
                ShouldLoadPlugin = false,
            };
        }

        [Fact]
        public void PluginSettingsXmlSavesLoads()
        {
            SettingsJson.SavePluginSettings(_pluginSettings);
            PluginSettings loadedSettings = SettingsJson.LoadPluginSettings();
            Assert.Equal(_pluginSettings.ShouldLoadPlugin, loadedSettings.ShouldLoadPlugin);
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
