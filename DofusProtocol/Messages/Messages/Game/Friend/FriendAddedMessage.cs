using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendAddedMessage : Message
    {
        public const uint Id = 5599;

        public FriendAddedMessage(FriendInformations friendAdded)
        {
            FriendAdded = friendAdded;
        }

        public FriendAddedMessage()
        {
        }

        public override uint MessageId => Id;

        public FriendInformations FriendAdded { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(FriendAdded.TypeId);
            FriendAdded.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FriendAdded = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
            FriendAdded.Deserialize(reader);
        }
    }
}