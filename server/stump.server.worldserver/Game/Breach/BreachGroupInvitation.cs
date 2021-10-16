using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class BreachGroupInvitation
    {
        public BreachGroupInvitation(Character host, BreachInvitationOfferMessage message)
        {
            this.Host = host;
            this.Message = message;
        }

        public Character Host { get; set; }

        public BreachInvitationOfferMessage Message { get; set; }
    }
}