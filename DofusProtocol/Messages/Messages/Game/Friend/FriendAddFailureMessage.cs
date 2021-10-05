using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendAddFailureMessage : Message
    {
        public const uint Id = 5600;

        public FriendAddFailureMessage(sbyte reason)
        {
            Reason = reason;
        }

        public FriendAddFailureMessage()
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