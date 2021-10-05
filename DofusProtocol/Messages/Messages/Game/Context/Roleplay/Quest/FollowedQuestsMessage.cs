using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FollowedQuestsMessage : Message
    {
        public const uint Id = 6717;

        public FollowedQuestsMessage(QuestActiveDetailedInformations[] quests)
        {
            Quests = quests;
        }

        public FollowedQuestsMessage()
        {
        }

        public override uint MessageId => Id;

        public QuestActiveDetailedInformations[] Quests { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Quests.Count());
            for (var questsIndex = 0; questsIndex < Quests.Count(); questsIndex++)
            {
                var objectToSend = Quests[questsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var questsCount = reader.ReadUShort();
            Quests = new QuestActiveDetailedInformations[questsCount];
            for (var questsIndex = 0; questsIndex < questsCount; questsIndex++)
            {
                var objectToAdd = new QuestActiveDetailedInformations();
                objectToAdd.Deserialize(reader);
                Quests[questsIndex] = objectToAdd;
            }
        }
    }
}