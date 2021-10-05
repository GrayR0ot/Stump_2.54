using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountRenamedMessage : Message
    {
        public const uint Id = 5983;

        public MountRenamedMessage(int mountId, string name)
        {
            MountId = mountId;
            Name = name;
        }

        public MountRenamedMessage()
        {
        }

        public override uint MessageId => Id;

        public int MountId { get; set; }
        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
            Name = reader.ReadUTF();
        }
    }
}