// Author: John Berlien
// Copyright:   Copyright 2022 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.

namespace OpenTap.Plugins.PreLoadCode.TestSteps
{
    [Display("Post-Load Step", Group: "OpenTap.Plugins.PreLoadCode", Description: "Displays message once plugin is fully loaded")]
    public class PostLoadStep : TestStep
    {
        public override void Run()
        {
            Log.Info("Plugin now fully loaded!");
        }
    }
}
