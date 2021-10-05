using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class SpellsPreset : Preset
    {
        public new const short Id = 519;

        public SpellsPreset(short objectId, SpellForPreset[] spells)
        {
            ObjectId = objectId;
            Spells = spells;
        }

        public SpellsPreset()
        {
        }

        public override short TypeId => Id;

        public SpellForPreset[] Spells { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Spells.Count());
            for (var spellsIndex = 0; spellsIndex < Spells.Count(); spellsIndex++)
            {
                var objectToSend = Spells[spellsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var spellsCount = reader.ReadUShort();
            Spells = new SpellForPreset[spellsCount];
            for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
            {
                var objectToAdd = new SpellForPreset();
                objectToAdd.Deserialize(reader);
                Spells[spellsIndex] = objectToAdd;
            }
        }
    }
}