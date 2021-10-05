using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeObjectTransfertListWithQuantityToInvMessage : Message
    {
        public const uint Id = 6470;

        public ExchangeObjectTransfertListWithQuantityToInvMessage(uint[] ids, uint[] qtys)
        {
            Ids = ids;
            Qtys = qtys;
        }

        public ExchangeObjectTransfertListWithQuantityToInvMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] Ids { get; set; }
        public uint[] Qtys { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Ids.Count());
            for (var idsIndex = 0; idsIndex < Ids.Count(); idsIndex++) writer.WriteVarUInt(Ids[idsIndex]);
            writer.WriteShort((short) Qtys.Count());
            for (var qtysIndex = 0; qtysIndex < Qtys.Count(); qtysIndex++) writer.WriteVarUInt(Qtys[qtysIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new uint[idsCount];
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++) Ids[idsIndex] = reader.ReadVarUInt();
            var qtysCount = reader.ReadUShort();
            Qtys = new uint[qtysCount];
            for (var qtysIndex = 0; qtysIndex < qtysCount; qtysIndex++) Qtys[qtysIndex] = reader.ReadVarUInt();
        }
    }
}