using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace KillLogs.Handlers
{
    internal class Dying
    {
        private Config config => KillLogs.Instance.Config;

        public void OnDying(DyingEventArgs ev)
        {
            string message = Functions.DeathMessageText(ev);

            foreach (var player in Player.List)
            {
                if (Functions.CanSeeDeathMessages(player))
                {
                    player.ClearBroadcasts();
                    player.Broadcast(config.BroadcastTime, message);
                }
            }
        }
    }
}