using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendSetStatusShareMessage : Message
    {
        public const uint Id = 6822;

        public FriendSetStatusShareMessage(bool share)
        {
            Share = share;
        }

        public FriendSetStatusShareMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Share { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Share);
        }

        public override void Deserialize(IDataReader reader)
        {
            Share = reader.ReadBoolean();
        }
    }
}