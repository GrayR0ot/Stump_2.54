using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FriendSpouseOnlineInformations : FriendSpouseInformations
    {
        public new const short Id = 93;

        public FriendSpouseOnlineInformations(int spouseAccountId, ulong spouseId, string spouseName,
            ushort spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook, BasicGuildInformations guildInfo,
            sbyte alignmentSide, bool inFight, bool followSpouse, bool pvpEnabled, int mapId, short subAreaId)
            : base(spouseAccountId, spouseId, spouseName, spouseLevel, breed, sex, spouseEntityLook,
                (GuildInformations) guildInfo, alignmentSide)
        {
            InFight = inFight;
            FollowSpouse = followSpouse;
            MapId = mapId;
            SubAreaId = (ushort) subAreaId;
        }

        public FriendSpouseOnlineInformations()
        {
        }

        public override short TypeId => Id;

        public bool InFight { get; set; }
        public bool FollowSpouse { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, InFight);
            flag = BooleanByteWrapper.SetFlag(flag, 1, FollowSpouse);
            writer.WriteByte(flag);
            writer.WriteDouble(MapId);
            writer.WriteVarUShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            InFight = BooleanByteWrapper.GetFlag(flag, 0);
            FollowSpouse = BooleanByteWrapper.GetFlag(flag, 1);
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUShort();
        }
    }
}