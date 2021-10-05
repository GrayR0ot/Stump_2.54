using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HavenBagPermissionsUpdateMessage : Message
    {
        public const uint Id = 6713;

        public HavenBagPermissionsUpdateMessage(int permissions)
        {
            Permissions = permissions;
        }

        public HavenBagPermissionsUpdateMessage()
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