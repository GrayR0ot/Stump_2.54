using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendSetWarnOnConnectionMessage : Message
    {
        public const uint Id = 5602;

        public FriendSetWarnOnConnectionMessage(bool enable)
        {
            Enable = enable;
        }

        public FriendSetWarnOnConnectionMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}