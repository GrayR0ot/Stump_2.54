using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeObjectTransfertListFromInvMessage : Message
    {
        public const uint Id = 6183;

        public ExchangeObjectTransfertListFromInvMessage(uint[] ids)
        {
            Ids = ids;
        }

        public ExchangeObjectTransfertListFromInvMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] Ids { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Ids.Count());
            for (var idsIndex = 0; idsIndex < Ids.Count(); idsIndex++) writer.WriteVarUInt(Ids[idsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new uint[idsCount];
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++) Ids[idsIndex] = reader.ReadVarUInt();
        }
    }
}