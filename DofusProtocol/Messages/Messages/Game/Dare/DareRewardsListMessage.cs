using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareRewardsListMessage : Message
    {
        public const uint Id = 6677;

        public DareRewardsListMessage(DareReward[] rewards)
        {
            Rewards = rewards;
        }

        public DareRewardsListMessage()
        {
        }

        public override uint MessageId => Id;

        public DareReward[] Rewards { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Rewards.Count());
            for (var rewardsIndex = 0; rewardsIndex < Rewards.Count(); rewardsIndex++)
            {
                var objectToSend = Rewards[rewardsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var rewardsCount = reader.ReadUShort();
            Rewards = new DareReward[rewardsCount];
            for (var rewardsIndex = 0; rewardsIndex < rewardsCount; rewardsIndex++)
            {
                var objectToAdd = new DareReward();
                objectToAdd.Deserialize(reader);
                Rewards[rewardsIndex] = objectToAdd;
            }
        }
    }
}