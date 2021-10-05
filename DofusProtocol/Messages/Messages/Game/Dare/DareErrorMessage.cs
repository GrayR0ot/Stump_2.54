using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareErrorMessage : Message
    {
        public const uint Id = 6667;

        public DareErrorMessage(sbyte error)
        {
            Error = error;
        }

        public DareErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Error { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Error);
        }

        public override void Deserialize(IDataReader reader)
        {
            Error = reader.ReadSByte();
        }
    }
}