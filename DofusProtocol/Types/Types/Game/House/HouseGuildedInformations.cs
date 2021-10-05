using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class HouseGuildedInformations : HouseInstanceInformations
    {
        public new const short Id = 512;

        public HouseGuildedInformations(bool secondHand, bool isLocked, bool isSaleLocked, int instanceId,
            string ownerName, long price, GuildInformations guildInfo)
        {
            SecondHand = secondHand;
            IsLocked = isLocked;
            IsSaleLocked = isSaleLocked;
            InstanceId = instanceId;
            OwnerName = ownerName;
            Price = price;
            GuildInfo = guildInfo;
        }

        public HouseGuildedInformations()
        {
        }

        public override short TypeId => Id;

        public GuildInformations GuildInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}