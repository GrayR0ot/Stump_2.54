using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntShowLegendaryUIMessage : Message
    {
        public const uint Id = 6498;

        public TreasureHuntShowLegendaryUIMessage(ushort[] availableLegendaryIds)
        {
            AvailableLegendaryIds = availableLegendaryIds;
        }

        public TreasureHuntShowLegendaryUIMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] AvailableLegendaryIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) AvailableLegendaryIds.Count());
            for (var availableLegendaryIdsIndex = 0;
                availableLegendaryIdsIndex < AvailableLegendaryIds.Count();
                availableLegendaryIdsIndex++) writer.WriteVarUShort(AvailableLegendaryIds[availableLegendaryIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var availableLegendaryIdsCount = reader.ReadUShort();
            AvailableLegendaryIds = new ushort[availableLegendaryIdsCount];
            for (var availableLegendaryIdsIndex = 0;
                availableLegendaryIdsIndex < availableLegendaryIdsCount;
                availableLegendaryIdsIndex++)
                AvailableLegendaryIds[availableLegendaryIdsIndex] = reader.ReadVarUShort();
        }
    }
}