// Author: John Berlien
// Copyright:   Copyright 2022 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.

using OpenTap.Plugins.PreLoadCode.Settings;

namespace OpenTap.Plugins.PreLoadCode.TestSteps
{
    [Display("SetPluginSettingsStep", Group: "OpenTap.Plugins.PreLoadCode", Description: "Insert a description here")]
    public class SetPluginSettingsStep : TestStep
    {
        #region Settings
        public bool ShouldLoadPlugin { get; set; } = true;
        #endregion

        public SetPluginSettingsStep()
        {
            ShouldLoadPlugin = PluginSettings.CurrentSettings.ShouldLoadPlugin;
        }

        public override void Run()
        {
            PluginSettings.CurrentSettings.ShouldLoadPlugin = ShouldLoadPlugin;
            PluginSettings.SaveCurrentSettings();
        }
    }
}
