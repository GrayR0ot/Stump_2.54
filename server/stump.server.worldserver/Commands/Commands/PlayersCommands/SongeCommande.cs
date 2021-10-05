using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Commands.Commands.PlayersCommands
{
    public class SongeCommand : InGameCommand
    {
        public SongeCommand()
        {
            Aliases = new[] {"songes"};
            RequiredRole = RoleEnum.Administrator;
            Description = "En cours de développement";
            AddParameter("subcmd", "subcmd", "Sous commande", "info");
        }

        public override void Execute(GameTrigger trigger)
        {
            var subCommand = trigger.Get<string>("subcmd");
            switch (subCommand.ToUpper())
            {
                case "INFO":
                    trigger.Reply("Etage actuel en songes: " + trigger.Character.songesStep);
                    break;
                case "UP":
                    trigger.Character.songesStep++;
                    trigger.Reply("Etage actuel en songes: " + trigger.Character.songesStep);
                    break;
                case "DOWN":
                    trigger.Character.songesStep--;
                    trigger.Reply("Etage actuel en songes: " + trigger.Character.songesStep);
                    break;
                case "SAVE":
                    trigger.Character.SaveNow();
                    trigger.Reply("Etage actuel en songes: " + trigger.Character.songesStep);
                    break;
                default:
                    trigger.Character.SendServerMessage("Sous commande inconnue !");
                    break;
            }
        }
    }
}