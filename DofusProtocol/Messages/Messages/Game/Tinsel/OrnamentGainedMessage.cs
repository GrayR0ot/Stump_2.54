using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class OrnamentGainedMessage : Message
    {
        public const uint Id = 6368;

        public OrnamentGainedMessage(short ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public OrnamentGainedMessage()
        {
        }

        public override uint MessageId => Id;

        public short OrnamentId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(OrnamentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OrnamentId = reader.ReadShort();
        }
    }
}