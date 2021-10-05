using System;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Alliances
{
    internal class AllianceInvitationRequest
    {
        private Character character;
        private Character player;

        public AllianceInvitationRequest(Character player, Character character)
        {
            this.player = player;
            this.character = character;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}