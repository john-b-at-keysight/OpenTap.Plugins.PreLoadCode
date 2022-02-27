namespace OpenTap.Plugins.PreLoadCode.Settings
{
    internal class PluginSettings
    {
        public bool ShouldLoadPlugin { get; set; } = true;

        private static PluginSettings _currentSettings;
        public static PluginSettings CurrentSettings
        {
            get
            {
                try
                {
                    _currentSettings ??= PluginSettingsIO.LoadPluginSettings();
                }
                catch
                {
                    _currentSettings = new PluginSettings();
                }
                return _currentSettings;
            }
        }

        public static void SaveCurrentSettings()
        {
            PluginSettingsIO.SavePluginSettings(CurrentSettings);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is not PluginSettings)
                return false;
            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.GetGetMethod() is null)
                    continue;
                if (property.GetGetMethod().IsStatic)
                    continue;
                object thisPropValue = property.GetValue(this);
                object objPropValue = property.GetValue(obj);
                if (!thisPropValue.Equals(objPropValue))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator == (PluginSettings obj1, PluginSettings obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator != (PluginSettings obj1, PluginSettings obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
