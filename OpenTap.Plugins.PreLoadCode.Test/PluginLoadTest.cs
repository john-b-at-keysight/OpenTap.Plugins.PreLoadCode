using System;
using System.Collections.Generic;
using Xunit;
using OpenTap.Plugins.PreLoadCode.TestSteps;
using OpenTap.Diagnostic;
using OpenTap.Plugins.PreLoadCode.Settings;
using OpenTap.Plugins.PreLoadCode.TapSettings;

namespace OpenTap.Plugins.PreLoadCode.Test
{
    public class PluginLoadTest
    {
        private readonly PreLoadCodeLogListener _listener = new();

        public PluginLoadTest()
        {
            PluginManager.Search();
            Log.AddListener(_listener);
        }

        [Fact]
        public void PreLoadCodeExceptionPreventsPluginLoad()
        {
            PluginSettings.CurrentSettings.ShouldLoadPlugin = false;
            PluginSettings.SaveCurrentSettings();
            Assert.Equal(PluginSettings.CurrentSettings.ShouldLoadPlugin,
                PreLoadCodeTapSettings.Current.ShouldLoadPluginNextStart);
            TestPlan testPlan = new();
            try
            {
                testPlan.ChildTestSteps.Add(new PostLoadStep());
                testPlan.Execute();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return;
            }
            throw new Exception("No exception thrown");
        }

        [Fact]
        public void PreLoadCodeRunsBeforeTestStepLoads()
        {
            TestPlan testPlan = new();
            testPlan.ChildTestSteps.Add(new PostLoadStep());
            testPlan.Execute();
            Assert.True(_listener.PreLoadCodeRunBeforeTestStepLoaded());
        }
    }

    internal class PreLoadCodeLogListener : ILogListener
    {
        public long PreLoadCodeRunTimeStamp { get; private set; } = 0;

        public long TestStepLoadedTimeStamp { get; private set; } = 0;

        public void EventsLogged(IEnumerable<Event> Events)
        {
            foreach (Event logEvent in Events)
            {
                ProcessLogEvent(logEvent);
            }
        }

        private void ProcessLogEvent(Event logEvent)
        {
            if (logEvent.Source == PrePluginLoad.LogSourceName)
            {
                if (logEvent.Message == PrePluginLoad.PreLoadMessage)
                    PreLoadCodeRunTimeStamp = logEvent.Timestamp;
            }
            else if (logEvent.Source == nameof(TestStep))
            {
                TestStepLoadedTimeStamp = logEvent.Timestamp;
            }
        }

        public bool PreLoadCodeRunBeforeTestStepLoaded()
        {
            return TestStepLoadedTimeStamp > PreLoadCodeRunTimeStamp;
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }
    }
}
