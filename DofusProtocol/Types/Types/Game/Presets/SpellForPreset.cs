using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class SpellForPreset
    {
        public const short Id = 557;

        public SpellForPreset(ushort spellId, short[] shortcuts)
        {
            SpellId = spellId;
            Shortcuts = shortcuts;
        }

        public SpellForPreset()
        {
        }

        public virtual short TypeId => Id;

        public ushort SpellId { get; set; }
        public short[] Shortcuts { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SpellId);
            writer.WriteShort((short) Shortcuts.Count());
            for (var shortcutsIndex = 0; shortcutsIndex < Shortcuts.Count(); shortcutsIndex++)
                writer.WriteShort(Shortcuts[shortcutsIndex]);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUShort();
            var shortcutsCount = reader.ReadUShort();
            Shortcuts = new short[shortcutsCount];
            for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
                Shortcuts[shortcutsIndex] = reader.ReadShort();
        }
    }
}