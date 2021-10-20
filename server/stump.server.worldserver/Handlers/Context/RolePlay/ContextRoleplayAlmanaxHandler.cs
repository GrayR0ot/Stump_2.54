using System;
using Stump.Core.Extensions;
using Stump.Core.Mathematics;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.Handlers.Context.RolePlay
{
    public partial class ContextRoleplayHandler : WorldHandlerContainer
    {
        [WorldHandler(AnomalySubareaInformationRequestMessage.Id)]
        public static void HandmeAnomalySubareaInformationRequestMessage(WorldClient client,
            AnomalySubareaInformationRequestMessage message)
        {
            AnomalySubareaInformation[] subAreas = new AnomalySubareaInformation[]{};
            foreach (var subArea in World.Instance.GetSubAreas())
            {
                subAreas = subAreas.Add(new AnomalySubareaInformation(
                    (ushort)subArea.Id,
                    subArea.Bonus,
                    false,
                    0
                ));
            }
            client.Send(new AnomalySubareaInformationResponseMessage(subAreas));
        }
    }
}