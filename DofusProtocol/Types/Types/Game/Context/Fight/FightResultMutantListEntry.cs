using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public new const short Id = 216;

        public FightResultMutantListEntry(ushort outcome, sbyte wave, FightLoot rewards, double objectId, bool alive,
            ushort level)
        {
            Outcome = outcome;
            Wave = wave;
            Rewards = rewards;
            ObjectId = objectId;
            Alive = alive;
            Level = level;
        }

        public FightResultMutantListEntry()
        {
        }

        public override short TypeId => Id;

        public ushort Level { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUShort();
        }
    }
}