using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildInvitationByNameMessage : Message
    {
        public const uint Id = 6115;

        public GuildInvitationByNameMessage(string name)
        {
            Name = name;
        }

        public GuildInvitationByNameMessage()
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