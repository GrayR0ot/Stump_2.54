using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class Shortcut
    {
        public const short Id = 369;

        public Shortcut(sbyte slot)
        {
            Slot = slot;
        }

        public Shortcut()
        {
        }

        public virtual short TypeId => Id;

        public sbyte Slot { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Slot);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Slot = reader.ReadSByte();
        }
    }
}