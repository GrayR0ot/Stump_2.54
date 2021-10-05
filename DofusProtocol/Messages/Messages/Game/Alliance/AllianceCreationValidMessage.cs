using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceCreationValidMessage : Message
    {
        public const uint Id = 6393;

        public AllianceCreationValidMessage(string allianceName, string allianceTag, GuildEmblem allianceEmblem)
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
            AllianceEmblem = allianceEmblem;
        }

        public AllianceCreationValidMessage()
        {
        }

        public override uint MessageId => Id;

        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public GuildEmblem AllianceEmblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
            AllianceEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
            AllianceEmblem = new GuildEmblem();
            AllianceEmblem.Deserialize(reader);
        }
    }
}