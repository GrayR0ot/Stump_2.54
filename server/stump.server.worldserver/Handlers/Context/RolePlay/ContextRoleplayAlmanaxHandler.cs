using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Core.Network;

namespace Stump.Server.WorldServer.Handlers.Context.RolePlay
{
    public partial class ContextRoleplayHandler : WorldHandlerContainer
    {
        [WorldHandler(AnomalySubareaInformationRequestMessage.Id)]
        public static void HandmeAnomalySubareaInformationRequestMessage(WorldClient client,
            AnomalySubareaInformationRequestMessage message)
        {
            client.Send(new AnomalySubareaInformationResponseMessage(new AnomalySubareaInformation[] { }));
        }
    }
}