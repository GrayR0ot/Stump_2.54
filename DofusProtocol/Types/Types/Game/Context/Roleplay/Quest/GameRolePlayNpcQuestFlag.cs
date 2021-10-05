using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayNpcQuestFlag
    {
        public const short Id = 384;

        public GameRolePlayNpcQuestFlag(ushort[] questsToValidId, ushort[] questsToStartId)
        {
            QuestsToValidId = questsToValidId;
            QuestsToStartId = questsToStartId;
        }

        public GameRolePlayNpcQuestFlag()
        {
        }

        public virtual short TypeId => Id;

        public ushort[] QuestsToValidId { get; set; }
        public ushort[] QuestsToStartId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) QuestsToValidId.Count());
            for (var questsToValidIdIndex = 0; questsToValidIdIndex < QuestsToValidId.Count(); questsToValidIdIndex++)
                writer.WriteVarUShort(QuestsToValidId[questsToValidIdIndex]);
            writer.WriteShort((short) QuestsToStartId.Count());
            for (var questsToStartIdIndex = 0; questsToStartIdIndex < QuestsToStartId.Count(); questsToStartIdIndex++)
                writer.WriteVarUShort(QuestsToStartId[questsToStartIdIndex]);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            var questsToValidIdCount = reader.ReadUShort();
            QuestsToValidId = new ushort[questsToValidIdCount];
            for (var questsToValidIdIndex = 0; questsToValidIdIndex < questsToValidIdCount; questsToValidIdIndex++)
                QuestsToValidId[questsToValidIdIndex] = reader.ReadVarUShort();
            var questsToStartIdCount = reader.ReadUShort();
            QuestsToStartId = new ushort[questsToStartIdCount];
            for (var questsToStartIdIndex = 0; questsToStartIdIndex < questsToStartIdCount; questsToStartIdIndex++)
                QuestsToStartId[questsToStartIdIndex] = reader.ReadVarUShort();
        }
    }
}