using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeMountsStableBornAddMessage : ExchangeMountsStableAddMessage
    {
        public new const uint Id = 6557;

        public ExchangeMountsStableBornAddMessage(MountClientData[] mountDescription)
        {
            MountDescription = mountDescription;
        }

        public ExchangeMountsStableBornAddMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}