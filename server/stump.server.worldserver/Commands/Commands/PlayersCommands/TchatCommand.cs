using System.Drawing;
using Stump.Core.Attributes;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class ChatCommand : CommandBase
    {
        [Variable(true)] public static string ChatColor = ColorTranslator.ToHtml(Color.Yellow);

        public ChatCommand()
        {
            Aliases = new[] {"m", "monde"};
            Description = "Display an announce to all players";
            RequiredRole = RoleEnum.Player;
            AddParameter<string>("message", "msg", "The announce");
        }

        public override void Execute(TriggerBase trigger)
        {
            var color = ColorTranslator.FromHtml(ChatColor);

            var msg = trigger.Get<string>("msg");
            var formatMsg = trigger is GameTrigger
                ? string.Format("(Monde) {0} : {1}", ((GameTrigger) trigger).Character.Name, msg)
                : string.Format("(Monde) {0} :)", msg);

            World.Instance.SendAnnounce(formatMsg, color);
        }
    }
}