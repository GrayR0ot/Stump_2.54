using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game.Fights;

namespace Stump.Server.WorldServer.Commands.Commands
{
    internal class HealCommand : InGameCommand
    {
        public HealCommand()
        {
            Aliases = new[] {"HP"};
            Description = "Rend l'intégralité des points de vie.";
            RequiredRole = RoleEnum.GameMaster;
        }

        public override void Execute(GameTrigger trigger)
        {
            var player = trigger.Character;
            if (!player.IsFighting())
            {
                player.Record.DamageTaken = 0;
                player.Stats.Health.DamageTaken = 0;
                player.RefreshStats();
                player.SaveLater();
            }
            else
            {
                if (player.Fight.State == FightState.Placement)
                {
                    player.Record.DamageTaken = 0;
                    player.Stats.Health.DamageTaken = 0;
                    player.RefreshStats();
                    player.SaveLater();
                }
                else
                {
                    trigger.ReplyError("Action impossible en combat...", Color.Red);
                }
            }
        }
    }
}