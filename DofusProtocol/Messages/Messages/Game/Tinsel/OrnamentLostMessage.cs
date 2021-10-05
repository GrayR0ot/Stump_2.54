using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class OrnamentLostMessage : Message
    {
        public const uint Id = 6770;

        public OrnamentLostMessage(short ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public OrnamentLostMessage()
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