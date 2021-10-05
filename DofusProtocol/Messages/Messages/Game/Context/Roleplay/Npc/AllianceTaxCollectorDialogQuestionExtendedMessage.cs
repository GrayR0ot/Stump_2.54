using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
    {
        public new const uint Id = 6445;

        public AllianceTaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo, ushort maxPods,
            ushort prospecting, ushort wisdom, sbyte taxCollectorsCount, int taxCollectorAttack, ulong kamas,
            ulong experience, uint pods, ulong itemsValue, BasicNamedAllianceInformations alliance)
        {
            GuildInfo = guildInfo;
            MaxPods = maxPods;
            Prospecting = prospecting;
            Wisdom = wisdom;
            TaxCollectorsCount = taxCollectorsCount;
            TaxCollectorAttack = taxCollectorAttack;
            Kamas = kamas;
            Experience = experience;
            Pods = pods;
            ItemsValue = itemsValue;
            Alliance = alliance;
        }

        public AllianceTaxCollectorDialogQuestionExtendedMessage()
        {
        }

        public override uint MessageId => Id;

        public BasicNamedAllianceInformations Alliance { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicNamedAllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}