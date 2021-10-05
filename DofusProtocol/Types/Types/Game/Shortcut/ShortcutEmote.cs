using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ShortcutEmote : Shortcut
    {
        public new const short Id = 389;

        public ShortcutEmote(sbyte slot, byte emoteId)
        {
            Slot = slot;
            EmoteId = emoteId;
        }

        public ShortcutEmote()
        {
        }

        public override short TypeId => Id;

        public byte EmoteId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EmoteId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EmoteId = reader.ReadByte();
        }
    }
}