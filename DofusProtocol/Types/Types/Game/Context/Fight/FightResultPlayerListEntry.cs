using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightResultPlayerListEntry : FightResultFighterListEntry
    {
        public new const short Id = 24;

        public FightResultPlayerListEntry(ushort outcome, sbyte wave, FightLoot rewards, double objectId, bool alive,
            ushort level, FightResultAdditionalData[] additional)
        {
            Outcome = outcome;
            Wave = wave;
            Rewards = rewards;
            ObjectId = objectId;
            Alive = alive;
            Level = level;
            Additional = additional;
        }

        public FightResultPlayerListEntry()
        {
        }

        public override short TypeId => Id;

        public ushort Level { get; set; }
        public FightResultAdditionalData[] Additional { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(Level);
            writer.WriteShort((short) Additional.Count());
            for (var additionalIndex = 0; additionalIndex < Additional.Count(); additionalIndex++)
            {
                var objectToSend = Additional[additionalIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUShort();
            var additionalCount = reader.ReadUShort();
            Additional = new FightResultAdditionalData[additionalCount];
            for (var additionalIndex = 0; additionalIndex < additionalCount; additionalIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<FightResultAdditionalData>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Additional[additionalIndex] = objectToAdd;
            }
        }
    }
}