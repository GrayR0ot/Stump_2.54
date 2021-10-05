using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Core.Network;

namespace Stump.Server.WorldServer.Handlers.Characters
{
    public partial class CharacterHandler : WorldHandlerContainer
    {
        [WorldHandler(CharacterReplayRequestMessage.Id, ShouldBeLogged = false, IsGamePacket = false)]
        public static void HandleCharacterReplayRequestMessage(WorldClient client,
            CharacterReplayRequestMessage message)
        {
            // TODO mhh ?
        }
    }
}