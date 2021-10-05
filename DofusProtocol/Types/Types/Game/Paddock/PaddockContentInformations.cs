using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PaddockContentInformations : PaddockInformations
    {
        public new const short Id = 183;

        public PaddockContentInformations(ushort maxOutdoorMount, ushort maxItems, double paddockId, short worldX,
            short worldY, double mapId, ushort subAreaId, bool abandonned,
            MountInformationsForPaddock[] mountsInformations)
        {
            MaxOutdoorMount = maxOutdoorMount;
            MaxItems = maxItems;
            PaddockId = paddockId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Abandonned = abandonned;
            MountsInformations = mountsInformations;
        }

        public PaddockContentInformations()
        {
        }

        public override short TypeId => Id;

        public double PaddockId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public bool Abandonned { get; set; }
        public MountInformationsForPaddock[] MountsInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(PaddockId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUShort(SubAreaId);
            writer.WriteBoolean(Abandonned);
            writer.WriteShort((short) MountsInformations.Count());
            for (var mountsInformationsIndex = 0;
                mountsInformationsIndex < MountsInformations.Count();
                mountsInformationsIndex++)
            {
                var objectToSend = MountsInformations[mountsInformationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PaddockId = reader.ReadDouble();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUShort();
            Abandonned = reader.ReadBoolean();
            var mountsInformationsCount = reader.ReadUShort();
            MountsInformations = new MountInformationsForPaddock[mountsInformationsCount];
            for (var mountsInformationsIndex = 0;
                mountsInformationsIndex < mountsInformationsCount;
                mountsInformationsIndex++)
            {
                var objectToAdd = new MountInformationsForPaddock();
                objectToAdd.Deserialize(reader);
                MountsInformations[mountsInformationsIndex] = objectToAdd;
            }
        }
    }
}