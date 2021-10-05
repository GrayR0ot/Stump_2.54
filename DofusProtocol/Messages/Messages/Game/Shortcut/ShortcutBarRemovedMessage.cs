using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ShortcutBarRemovedMessage : Message
    {
        public const uint Id = 6224;

        public ShortcutBarRemovedMessage(sbyte barType, sbyte slot)
        {
            BarType = barType;
            Slot = slot;
        }

        public ShortcutBarRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte BarType { get; set; }
        public sbyte Slot { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(BarType);
            writer.WriteSByte(Slot);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadSByte();
            Slot = reader.ReadSByte();
        }
    }
}