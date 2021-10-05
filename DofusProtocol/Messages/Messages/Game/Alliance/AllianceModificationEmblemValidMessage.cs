using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceModificationEmblemValidMessage : Message
    {
        public const uint Id = 6447;

        public AllianceModificationEmblemValidMessage(GuildEmblem alliancemblem)
        {
            Alliancemblem = alliancemblem;
        }

        public AllianceModificationEmblemValidMessage()
        {
        }

        public override uint MessageId => Id;

        public GuildEmblem Alliancemblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }
    }
}