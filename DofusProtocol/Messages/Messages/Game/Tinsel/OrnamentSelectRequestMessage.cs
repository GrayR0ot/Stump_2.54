using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class OrnamentSelectRequestMessage : Message
    {
        public const uint Id = 6374;

        public OrnamentSelectRequestMessage(ushort ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public OrnamentSelectRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort OrnamentId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(OrnamentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OrnamentId = reader.ReadVarUShort();
        }
    }
}