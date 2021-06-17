using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillLogs
{
    internal static class Functions
    {
        private static Config config => KillLogs.Instance.Config;

        private static Dictionary<RoleType, string> RoleColours = new Dictionary<RoleType, string>
        {
            {RoleType.Scp173, "#ff0000" },
            {RoleType.ClassD, "#" }
        };

        public static bool CanSeeDeathMessages(Player player)
        {
            if (player.Team == Team.RIP ||
            (config.TutorialSeeDeathMessages && player.Team == Team.TUT))
            {
                return true;
            }

            return false;
        }

        public static string DeathMessageText(DyingEventArgs ev)
        {
            string message = $"{ColouredName(ev.Target)}({ColouredRole(ev.Target)})";

            if (ev.Killer == ev.Target)
            {
                return $"{message} died by {ev.HitInformation.GetDamageName()}";
            }

            message += $" was killed by {ColouredName(ev.Killer)}({ColouredRole(ev.Killer)})";

            if (ev.Killer.Team == Team.SCP)
            {
                return message;
            }

            return message + $" using {ev.HitInformation.GetDamageName()}";
        }

        private static string ColouredName(Player player)
        {
            return Colored(player, player.Nickname);
        }

        private static string ColouredRole(Player player)
        {
            return Colored(player, player.Role.ToString());
        }

        private static string Colored(Player player, string infix)
        {
            string color = player.RoleColor.ToHex();
            return $"<color={color}>{infix}</color>";
        }
    }
}