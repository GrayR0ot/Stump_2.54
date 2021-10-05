using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class MapCoordinatesExtended : MapCoordinatesAndId
    {
        public new const short Id = 176;

        public MapCoordinatesExtended(short worldX, short worldY, double mapId, ushort subAreaId)
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public MapCoordinatesExtended()
        {
        }

        public override short TypeId => Id;

        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SubAreaId = reader.ReadVarUShort();
        }
    }
}