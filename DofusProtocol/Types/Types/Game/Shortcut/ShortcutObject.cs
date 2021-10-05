using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ShortcutObject : Shortcut
    {
        public new const short Id = 367;

        public ShortcutObject(sbyte slot)
        {
            Slot = slot;
        }

        public ShortcutObject()
        {
        }

        public override short TypeId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}