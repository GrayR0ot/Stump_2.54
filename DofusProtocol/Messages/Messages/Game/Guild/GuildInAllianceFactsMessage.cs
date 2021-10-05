using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildInAllianceFactsMessage : GuildFactsMessage
    {
        public new const uint Id = 6422;

        public GuildInAllianceFactsMessage(GuildFactSheetInformations infos, int creationDate, ushort nbTaxCollectors,
            CharacterMinimalGuildPublicInformations[] members, BasicNamedAllianceInformations allianceInfos)
        {
            Infos = infos;
            CreationDate = creationDate;
            NbTaxCollectors = nbTaxCollectors;
            Members = members;
            AllianceInfos = allianceInfos;
        }

        public GuildInAllianceFactsMessage()
        {
        }

        public override uint MessageId => Id;

        public BasicNamedAllianceInformations AllianceInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInfos = new BasicNamedAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }
    }
}