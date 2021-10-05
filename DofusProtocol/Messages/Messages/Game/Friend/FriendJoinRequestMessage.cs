using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendJoinRequestMessage : Message
    {
        public const uint Id = 5605;

        public FriendJoinRequestMessage(string name)
        {
            Name = name;
        }

        public FriendJoinRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }
    }
}