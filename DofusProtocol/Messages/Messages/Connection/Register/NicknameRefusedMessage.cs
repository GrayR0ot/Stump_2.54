using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NicknameRefusedMessage : Message
    {
        public const uint Id = 5638;

        public NicknameRefusedMessage(sbyte reason)
        {
            Reason = reason;
        }

        public NicknameRefusedMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}