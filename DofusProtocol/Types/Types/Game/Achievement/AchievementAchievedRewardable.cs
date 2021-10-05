using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AchievementAchievedRewardable : AchievementAchieved
    {
        public new const short Id = 515;

        public AchievementAchievedRewardable(ushort objectId, ulong achievedBy, ushort finishedlevel)
        {
            ObjectId = objectId;
            AchievedBy = achievedBy;
            Finishedlevel = finishedlevel;
        }

        public AchievementAchievedRewardable()
        {
        }

        public override short TypeId => Id;

        public ushort Finishedlevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(Finishedlevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Finishedlevel = reader.ReadVarUShort();
        }
    }
}