using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MimicryObjectAssociatedMessage : SymbioticObjectAssociatedMessage
    {
        public new const uint Id = 6462;

        public MimicryObjectAssociatedMessage(uint hostUID)
        {
            HostUID = hostUID;
        }

        public MimicryObjectAssociatedMessage()
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