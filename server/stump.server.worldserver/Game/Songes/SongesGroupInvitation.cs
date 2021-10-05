using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class SongesGroupInvitation
    {
        private Character host;
        private BreachInvitationOfferMessage message;

        public SongesGroupInvitation(Character host, BreachInvitationOfferMessage message)
        {
            this.host = host;
            this.message = message;
        }

        public Character Host
        {
            get => host;
            set => host = value;
        }

        public BreachInvitationOfferMessage Message
        {
            get => message;
            set => message = value;
        }
    }
}