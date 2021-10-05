using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Stump.Server.WorldServer.Commands.Commands
{
    internal class IpDropCommand : InGameCommand
    {
        public IpDropCommand()
        {
            Aliases = new[] {"ipdrop"};
            Description = "Le personnage ayant activé cette commande recevra tous le drop de tous vos personnages.";
            RequiredRole = RoleEnum.Vip;
        }

        public override void Execute(GameTrigger trigger)
        {
            var character = trigger.Character;
            if (!character.IsIpDrop)
            {
                foreach (var otherCharacters in WorldServer.Instance.FindClients(x =>
                    x.IP == character.Client.IP && x.Character != character))
                    otherCharacters.Character.IsIpDrop = false;
                character.IsIpDrop = true;
                character.SendServerMessage("Vous avez activé l'ip drop.");
            }
            else
            {
                character.IsIpDrop = false;
                character.SendServerMessage("Vous avez désactivé l'ip drop.");
            }
        }
    }
}