using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountRenameRequestMessage : Message
    {
        public const uint Id = 5987;

        public MountRenameRequestMessage(string name, int mountId)
        {
            Name = name;
            MountId = mountId;
        }

        public MountRenameRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }
        public int MountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            MountId = reader.ReadVarInt();
        }
    }
}