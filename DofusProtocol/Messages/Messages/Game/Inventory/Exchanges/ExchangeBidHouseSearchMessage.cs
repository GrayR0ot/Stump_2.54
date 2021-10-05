using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseSearchMessage : Message
    {
        public const uint Id = 5806;

        public ExchangeBidHouseSearchMessage(uint type, ushort genId)
        {
            Type = type;
            GenId = genId;
        }

        public ExchangeBidHouseSearchMessage()
        {
        }

        public override uint MessageId => Id;

        public uint Type { get; set; }
        public ushort GenId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(Type);
            writer.WriteVarUShort(GenId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadVarUInt();
            GenId = reader.ReadVarUShort();
        }
    }
}