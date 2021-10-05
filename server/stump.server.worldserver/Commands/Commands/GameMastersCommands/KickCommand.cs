using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class KickCommand : TargetCommand
    {
        public KickCommand()
        {
            Aliases = new[] {"kick"};
            RequiredRole = RoleEnum.GameMaster_Padawan;
            Description = "Kick a player";

            AddTargetParameter();
        }

        public override void Execute(TriggerBase trigger)
        {
            foreach (var target in GetTargets(trigger))
            {
                var kicker = trigger is GameTrigger ? (trigger as GameTrigger).Character.Name : "Server";

                target.SendSystemMessage(18, true, kicker, string.Empty); // you were kicked by %1
                target.Client.Disconnect();

                trigger.Reply("You have kicked {0}", target.Name);
                World.Instance.SendAnnounce(
                    "★ Le joueur <b>" + target.Client.Character.Name + "</b>, c'est fait violemment éjécter !",
                    Color.Red);
            }
        }
    }
}