using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ShortcutSmiley : Shortcut
    {
        public new const short Id = 388;

        public ShortcutSmiley(sbyte slot, ushort smileyId)
        {
            Slot = slot;
            SmileyId = smileyId;
        }

        public ShortcutSmiley()
        {
        }

        public override short TypeId => Id;

        public ushort SmileyId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SmileyId = reader.ReadVarUShort();
        }
    }
}