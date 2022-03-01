using OpenTap.Plugins.PreLoadCode.Settings;

namespace OpenTap.Plugins.PreLoadCode.TapSettings
{
    [Display("PreLoadCode Plugin Settings", Description: "Settings for PreLoadCode plugin")]
    public class PreLoadCodeTapSettings : ComponentSettings<PreLoadCodeTapSettings>
    {
        [Display("Should Load Plugin On Next Start", "Set whether the plugin should be loaded on next start of OpenTAP or PathWave Test Automation Editor", "Plugin Load")]
        public bool ShouldLoadPluginNextStart
        {
            get
            {
                return PluginSettings.CurrentSettings.ShouldLoadPlugin;
            }
            set
            {
                PluginSettings.CurrentSettings.ShouldLoadPlugin = value;
                PluginSettings.SaveCurrentSettings();
            }
        }
    }
}
