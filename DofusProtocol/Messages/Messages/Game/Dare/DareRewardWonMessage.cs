using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareRewardWonMessage : Message
    {
        public const uint Id = 6678;

        public DareRewardWonMessage(DareReward reward)
        {
            Reward = reward;
        }

        public DareRewardWonMessage()
        {
        }

        public override uint MessageId => Id;

        public DareReward Reward { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Reward.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reward = new DareReward();
            Reward.Deserialize(reader);
        }
    }
}