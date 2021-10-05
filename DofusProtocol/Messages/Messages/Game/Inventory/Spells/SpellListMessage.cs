using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SpellListMessage : Message
    {
        public const uint Id = 1200;
        public bool spellPrevisualization;
        public IEnumerable<SpellItem> spells;

        public SpellListMessage(bool spellPrevisualization, IEnumerable<SpellItem> spells)
        {
            this.spellPrevisualization = spellPrevisualization;
            this.spells = spells;
        }

        public SpellListMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(spellPrevisualization);
            writer.WriteShort((short) spells.Count());
            foreach (var objectToSend in spells) objectToSend.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            spellPrevisualization = reader.ReadBoolean();
            var spellsCount = reader.ReadUShort();
            var spells_ = new SpellItem[spellsCount];
            for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
            {
                var objectToAdd = new SpellItem();
                objectToAdd.Deserialize(reader);
                spells_[spellsIndex] = objectToAdd;
            }

            spells = spells_;
        }
    }
}