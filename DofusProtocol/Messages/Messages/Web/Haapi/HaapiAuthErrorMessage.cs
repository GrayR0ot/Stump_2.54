using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HaapiAuthErrorMessage : Message
    {
        public const uint Id = 6768;

        public HaapiAuthErrorMessage(sbyte type)
        {
            Type = type;
        }

        public HaapiAuthErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
        }
    }
}