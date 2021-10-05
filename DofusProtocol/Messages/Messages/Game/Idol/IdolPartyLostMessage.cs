using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdolPartyLostMessage : Message
    {
        public const uint Id = 6580;

        public IdolPartyLostMessage(ushort idolId)
        {
            IdolId = idolId;
        }

        public IdolPartyLostMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort IdolId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolId = reader.ReadVarUShort();
        }
    }
}