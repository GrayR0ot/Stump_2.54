using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class TpGroupCommand : CommandBase
    {
        public TpGroupCommand()
        {
            Aliases = new[] {"tpgroupe", "tpgrp"};
            RequiredRole = RoleEnum.Player;
            Description = "Teleporte le groupe";
        }

        public override void Execute(TriggerBase trigger)
        {
            if (!(trigger as GameTrigger).Character.IsInParty())
            {
                (trigger as GameTrigger).Character.DisplayNotification(
                    "Vous ne pouvez pas utiliser cette commande car vous ne faites pas partie d'un groupe.");
                return;
            }

            if (!(trigger as GameTrigger).Character.IsPartyLeader())
            {
                (trigger as GameTrigger).Character.DisplayNotification(
                    "Vous ne pouvez pas utiliser cette commande car vous n'êtes pas le chef du groupe.");
                return;
            }

            if ((trigger as GameTrigger).Character.Party.Leader.Map.IsDungeon())
            {
                (trigger as GameTrigger).Character.DisplayNotification(
                    "Vous ne pouvez pas utiliser cette commande car votre chef est dans un donjon.");
                return;
            }

            var group = (trigger as GameTrigger).Character.Party;
            foreach (var characters in group.Members) characters.Teleport(group.Leader.Position);
        }
    }
}