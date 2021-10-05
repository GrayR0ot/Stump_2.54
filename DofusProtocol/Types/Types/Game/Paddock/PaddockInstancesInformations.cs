using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PaddockInstancesInformations : PaddockInformations
    {
        public new const short Id = 509;

        public PaddockInstancesInformations(ushort maxOutdoorMount, ushort maxItems,
            PaddockBuyableInformations[] paddocks)
        {
            MaxOutdoorMount = maxOutdoorMount;
            MaxItems = maxItems;
            Paddocks = paddocks;
        }

        public PaddockInstancesInformations()
        {
        }

        public override short TypeId => Id;

        public PaddockBuyableInformations[] Paddocks { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Paddocks.Count());
            for (var paddocksIndex = 0; paddocksIndex < Paddocks.Count(); paddocksIndex++)
            {
                var objectToSend = Paddocks[paddocksIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var paddocksCount = reader.ReadUShort();
            Paddocks = new PaddockBuyableInformations[paddocksCount];
            for (var paddocksIndex = 0; paddocksIndex < paddocksCount; paddocksIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<PaddockBuyableInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Paddocks[paddocksIndex] = objectToAdd;
            }
        }
    }
}