using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class OrnamentSelectedMessage : Message
    {
        public const uint Id = 6369;

        public OrnamentSelectedMessage(ushort ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public OrnamentSelectedMessage()
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