using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapNpcsQuestStatusUpdateMessage : Message
    {
        public const uint Id = 5642;

        public MapNpcsQuestStatusUpdateMessage(double mapId, int[] npcsIdsWithQuest,
            GameRolePlayNpcQuestFlag[] questFlags, int[] npcsIdsWithoutQuest)
        {
            MapId = mapId;
            NpcsIdsWithQuest = npcsIdsWithQuest;
            QuestFlags = questFlags;
            NpcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }

        public MapNpcsQuestStatusUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public double MapId { get; set; }
        public int[] NpcsIdsWithQuest { get; set; }
        public GameRolePlayNpcQuestFlag[] QuestFlags { get; set; }
        public int[] NpcsIdsWithoutQuest { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteShort((short) NpcsIdsWithQuest.Count());
            for (var npcsIdsWithQuestIndex = 0;
                npcsIdsWithQuestIndex < NpcsIdsWithQuest.Count();
                npcsIdsWithQuestIndex++) writer.WriteInt(NpcsIdsWithQuest[npcsIdsWithQuestIndex]);
            writer.WriteShort((short) QuestFlags.Count());
            for (var questFlagsIndex = 0; questFlagsIndex < QuestFlags.Count(); questFlagsIndex++)
            {
                var objectToSend = QuestFlags[questFlagsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) NpcsIdsWithoutQuest.Count());
            for (var npcsIdsWithoutQuestIndex = 0;
                npcsIdsWithoutQuestIndex < NpcsIdsWithoutQuest.Count();
                npcsIdsWithoutQuestIndex++) writer.WriteInt(NpcsIdsWithoutQuest[npcsIdsWithoutQuestIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            var npcsIdsWithQuestCount = reader.ReadUShort();
            NpcsIdsWithQuest = new int[npcsIdsWithQuestCount];
            for (var npcsIdsWithQuestIndex = 0; npcsIdsWithQuestIndex < npcsIdsWithQuestCount; npcsIdsWithQuestIndex++)
                NpcsIdsWithQuest[npcsIdsWithQuestIndex] = reader.ReadInt();
            var questFlagsCount = reader.ReadUShort();
            QuestFlags = new GameRolePlayNpcQuestFlag[questFlagsCount];
            for (var questFlagsIndex = 0; questFlagsIndex < questFlagsCount; questFlagsIndex++)
            {
                var objectToAdd = new GameRolePlayNpcQuestFlag();
                objectToAdd.Deserialize(reader);
                QuestFlags[questFlagsIndex] = objectToAdd;
            }

            var npcsIdsWithoutQuestCount = reader.ReadUShort();
            NpcsIdsWithoutQuest = new int[npcsIdsWithoutQuestCount];
            for (var npcsIdsWithoutQuestIndex = 0;
                npcsIdsWithoutQuestIndex < npcsIdsWithoutQuestCount;
                npcsIdsWithoutQuestIndex++) NpcsIdsWithoutQuest[npcsIdsWithoutQuestIndex] = reader.ReadInt();
        }
    }
}