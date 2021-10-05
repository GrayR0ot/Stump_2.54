using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class RefreshFollowedQuestsOrderRequestMessage : Message
    {
        public const uint Id = 6722;

        public RefreshFollowedQuestsOrderRequestMessage(ushort[] quests)
        {
            Quests = quests;
        }

        public RefreshFollowedQuestsOrderRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] Quests { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Quests.Count());
            for (var questsIndex = 0; questsIndex < Quests.Count(); questsIndex++)
                writer.WriteVarUShort(Quests[questsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var questsCount = reader.ReadUShort();
            Quests = new ushort[questsCount];
            for (var questsIndex = 0; questsIndex < questsCount; questsIndex++)
                Quests[questsIndex] = reader.ReadVarUShort();
        }
    }
}