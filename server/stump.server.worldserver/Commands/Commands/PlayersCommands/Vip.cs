using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;

namespace Commands.Commands
{
    public class VipCommand : SubCommandContainer
    {
        public VipCommand()
        {
            Aliases = new[]
            {
                "vip"
            };

            RequiredRole = RoleEnum.Player;
            Description = "Affiche les commandes disponible pour le V.I.P.";
        }
    }
}