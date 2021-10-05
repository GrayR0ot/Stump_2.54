using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ShortcutBarRemoveErrorMessage : Message
    {
        public const uint Id = 6222;

        public ShortcutBarRemoveErrorMessage(sbyte error)
        {
            Error = error;
        }

        public ShortcutBarRemoveErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Error { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Error);
        }

        public override void Deserialize(IDataReader reader)
        {
            Error = reader.ReadSByte();
        }
    }
}