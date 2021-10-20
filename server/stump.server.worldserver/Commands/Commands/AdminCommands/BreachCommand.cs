using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Commands.Commands.AdminCommands
{
    public class BreachCommand : InGameCommand
    {
        public BreachCommand()
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
                    trigger.Reply("Etage actuel en songes: " + trigger.Character.breachStep);
                    break;
                case "UP":
                    trigger.Character.breachStep++;
                    trigger.Reply("Etage actuel en breach: " + trigger.Character.breachStep);
                    break;
                case "DOWN":
                    trigger.Character.breachStep--;
                    trigger.Reply("Etage actuel en breach: " + trigger.Character.breachStep);
                    break;
                case "SAVE":
                    trigger.Character.SaveNow();
                    trigger.Reply("Etage actuel en breach: " + trigger.Character.breachStep);
                    break;
                default:
                    trigger.Character.SendServerMessage("Sous commande inconnue !");
                    break;
            }
        }
    }
}