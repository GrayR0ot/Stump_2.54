using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AccessoryPreviewErrorMessage : Message
    {
        public const uint Id = 6521;

        public AccessoryPreviewErrorMessage(sbyte error)
        {
            Error = error;
        }

        public AccessoryPreviewErrorMessage()
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