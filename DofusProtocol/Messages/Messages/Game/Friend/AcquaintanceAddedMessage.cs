using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AcquaintanceAddedMessage : Message
    {
        public const uint Id = 6818;

        public AcquaintanceAddedMessage(AcquaintanceInformation acquaintanceAdded)
        {
            AcquaintanceAdded = acquaintanceAdded;
        }

        public AcquaintanceAddedMessage()
        {
        }

        public override uint MessageId => Id;

        public AcquaintanceInformation AcquaintanceAdded { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(AcquaintanceAdded.TypeId);
            AcquaintanceAdded.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AcquaintanceAdded = ProtocolTypeManager.GetInstance<AcquaintanceInformation>(reader.ReadShort());
            AcquaintanceAdded.Deserialize(reader);
        }
    }
}