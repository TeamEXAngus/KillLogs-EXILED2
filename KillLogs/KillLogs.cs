using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace KillLogs
{
    public class KillLogs : Plugin<Config>
    {
        public static KillLogs Instance;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 1);

        private Handlers.Dying dying;

        public KillLogs()
        {
        }

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            dying = new Handlers.Dying();

            PlayerHandler.Dying += dying.OnDying;
        }

        public void UnregisterEvents()
        {
            PlayerHandler.Dying -= dying.OnDying;

            dying = null;
        }
    }
}