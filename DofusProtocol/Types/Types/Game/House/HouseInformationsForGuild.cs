using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class HouseInformationsForGuild : HouseInformations
    {
        public new const short Id = 170;

        public HouseInformationsForGuild(uint houseId, ushort modelId, int instanceId, bool secondHand,
            string ownerName, short worldX, short worldY, double mapId, ushort subAreaId, int[] skillListIds,
            uint guildshareParams)
        {
            HouseId = houseId;
            ModelId = modelId;
            InstanceId = instanceId;
            SecondHand = secondHand;
            OwnerName = ownerName;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            SkillListIds = skillListIds;
            GuildshareParams = guildshareParams;
        }

        public HouseInformationsForGuild()
        {
        }

        public override short TypeId => Id;

        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public string OwnerName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public int[] SkillListIds { get; set; }
        public uint GuildshareParams { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteUTF(OwnerName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUShort(SubAreaId);
            writer.WriteShort((short) SkillListIds.Count());
            for (var skillListIdsIndex = 0; skillListIdsIndex < SkillListIds.Count(); skillListIdsIndex++)
                writer.WriteInt(SkillListIds[skillListIdsIndex]);
            writer.WriteVarUInt(GuildshareParams);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            OwnerName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUShort();
            var skillListIdsCount = reader.ReadUShort();
            SkillListIds = new int[skillListIdsCount];
            for (var skillListIdsIndex = 0; skillListIdsIndex < skillListIdsCount; skillListIdsIndex++)
                SkillListIds[skillListIdsIndex] = reader.ReadInt();
            GuildshareParams = reader.ReadVarUInt();
        }
    }
}