using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class GroupCommand : InGameCommand
    {
        public GroupCommand()
        {
            Aliases = new[] {"master"};
            Description = "Permet d'inviter dans un groupe tous vos personnages.";
            RequiredRole = RoleEnum.Player;
        }

        public override void Execute(GameTrigger trigger)
        {
            var character = trigger.Character;

            foreach (var perso in WorldServer.Instance.FindClients(x =>
                x.IP == character.Client.IP && x.Character != character))
            {
                if (character.Party != null && character.Party.Members.Contains(perso.Character))
                    continue;

                character.Invite(perso.Character, PartyTypeEnum.PARTY_TYPE_CLASSICAL, true);
            }
        }
    }
}