using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class OrnamentSelectErrorMessage : Message
    {
        public const uint Id = 6370;

        public OrnamentSelectErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public OrnamentSelectErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}