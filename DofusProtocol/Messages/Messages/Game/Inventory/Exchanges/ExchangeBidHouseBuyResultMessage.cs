using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseBuyResultMessage : Message
    {
        public const uint Id = 6272;

        public ExchangeBidHouseBuyResultMessage(uint uid, bool bought)
        {
            Uid = uid;
            Bought = bought;
        }

        public ExchangeBidHouseBuyResultMessage()
        {
        }

        public override uint MessageId => Id;

        public uint Uid { get; set; }
        public bool Bought { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(Uid);
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUInt();
            Bought = reader.ReadBoolean();
        }
    }
}