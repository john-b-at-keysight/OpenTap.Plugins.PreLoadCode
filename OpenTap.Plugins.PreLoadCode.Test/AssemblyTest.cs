using System.Reflection;
using Xunit;

namespace OpenTap.Plugins.PreLoadCode.Test
{
    public class AssemblyTest
    {
        private const string _interpolatedConstString = $"{nameof(OpenTap)}.{nameof(Plugins)}.{nameof(PreLoadCode)}.{nameof(PrePluginLoad)}.{nameof(PrePluginLoad.RunBeforePluginLoad)}";
        private const string _prePluginMethodFullName = "OpenTap.Plugins.PreLoadCode.PrePluginLoad.RunBeforePluginLoad";
        
        [Fact]
        public void AssemblyAttributeConstNameMatchesMethodFullName()
        {
            Assert.Equal(_prePluginMethodFullName, _interpolatedConstString);
        }

        [Fact]
        public void AssemblyAttributeNameMatchesConstMethodName()
        {
            Assembly pluginAssembly = Assembly.LoadFrom("OpenTap.Plugins.PreLoadCode.dll");
            PluginAssemblyAttribute attribute = (PluginAssemblyAttribute)pluginAssembly.GetCustomAttribute(typeof(OpenTap.PluginAssemblyAttribute));
            Assert.Equal(_prePluginMethodFullName, attribute.PluginInitMethod);
        }
    }
}
