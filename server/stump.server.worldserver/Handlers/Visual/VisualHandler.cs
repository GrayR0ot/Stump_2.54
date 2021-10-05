using Stump.DofusProtocol.Messages;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Handlers.Visual
{
    internal class VisualHandler : WorldHandlerContainer
    {
        public static void SendGameRolePlaySpellAnimMessage(IPacketReceiver client, Character character, int cellId,
            int SpellId)
        {
            client.Send(new GameRolePlaySpellAnimMessage((ulong) character.Id, (ushort) cellId, (ushort) SpellId, 1));
        }
    }
}