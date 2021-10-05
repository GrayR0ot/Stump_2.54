using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendDeleteResultMessage : Message
    {
        public const uint Id = 5601;

        public FriendDeleteResultMessage(bool success, string name)
        {
            Success = success;
            Name = name;
        }

        public FriendDeleteResultMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Success { get; set; }
        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Success);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Success = reader.ReadBoolean();
            Name = reader.ReadUTF();
        }
    }
}