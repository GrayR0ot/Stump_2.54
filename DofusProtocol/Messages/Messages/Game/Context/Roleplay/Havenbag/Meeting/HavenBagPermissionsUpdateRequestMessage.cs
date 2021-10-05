using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HavenBagPermissionsUpdateRequestMessage : Message
    {
        public const uint Id = 6714;

        public HavenBagPermissionsUpdateRequestMessage(int permissions)
        {
            Permissions = permissions;
        }

        public HavenBagPermissionsUpdateRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public int Permissions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Permissions);
        }

        public override void Deserialize(IDataReader reader)
        {
            Permissions = reader.ReadInt();
        }
    }
}