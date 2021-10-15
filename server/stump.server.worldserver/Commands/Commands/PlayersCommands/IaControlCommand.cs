using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class IaControlCommand : InGameCommand
    {
        public IaControlCommand()
        {
            Aliases = new[] {"ia"};
            RequiredRole = RoleEnum.Administrator;
            Description = "Définit si vous souhaitez ou non controler l'ia";
        }

        public override void Execute(GameTrigger trigger)
        {
            var character = trigger.Character;
            if (character != null)
            {
                if (character.IAControl == false)
                {
                    character.IAControl = true;
                    character.SendServerMessage("Le contrôle des invocations est désormais activé.", Color.Green);
                }
                else
                {
                    character.IAControl = false;
                    character.SendServerMessage("Le contrôle des invocations est désormais désactivé.", Color.Red);
                }
            }
        }
    }
}