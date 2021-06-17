using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillLogs
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not Tutorials should see the death messages")]
        public bool TutorialSeeDeathMessages { get; set; } = true;

        [Description("The number of seconds which the death messages should be shown for")]
        public ushort BroadcastTime { get; set; } = 5;
    }
}