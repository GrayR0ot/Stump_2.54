using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class SpellItem : Item
    {
        public new const short Id = 49;

        public SpellItem(int spellId, short spellLevel)
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public SpellItem()
        {
        }

        public override short TypeId => Id;

        public int SpellId { get; set; }
        public short SpellLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadInt();
            SpellLevel = reader.ReadShort();
        }
    }
}