using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CompassResetMessage : Message
    {
        public const uint Id = 5584;

        public CompassResetMessage(sbyte type)
        {
            Type = type;
        }

        public CompassResetMessage()
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