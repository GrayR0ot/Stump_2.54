using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceModificationValidMessage : Message
    {
        public const uint Id = 6450;

        public AllianceModificationValidMessage(string allianceName, string allianceTag, GuildEmblem alliancemblem)
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
            Alliancemblem = alliancemblem;
        }

        public AllianceModificationValidMessage()
        {
        }

        public override uint MessageId => Id;

        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public GuildEmblem Alliancemblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }
    }
}