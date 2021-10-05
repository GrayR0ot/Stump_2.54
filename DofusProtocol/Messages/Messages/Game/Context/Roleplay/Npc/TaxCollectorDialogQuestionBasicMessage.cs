using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TaxCollectorDialogQuestionBasicMessage : Message
    {
        public const uint Id = 5619;

        public TaxCollectorDialogQuestionBasicMessage(BasicGuildInformations guildInfo)
        {
            GuildInfo = guildInfo;
        }

        public TaxCollectorDialogQuestionBasicMessage()
        {
        }

        public override uint MessageId => Id;

        public BasicGuildInformations GuildInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}