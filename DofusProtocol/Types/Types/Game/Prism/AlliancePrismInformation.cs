using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AlliancePrismInformation : PrismInformation
    {
        public new const short Id = 427;

        public AlliancePrismInformation(sbyte typeId, sbyte state, int nextVulnerabilityDate, int placementDate,
            uint rewardTokenCount, AllianceInformations alliance)
        {
            this.typeId = typeId;
            State = state;
            NextVulnerabilityDate = nextVulnerabilityDate;
            PlacementDate = placementDate;
            RewardTokenCount = rewardTokenCount;
            Alliance = alliance;
        }

        public AlliancePrismInformation()
        {
        }

        public override short TypeId => Id;

        public AllianceInformations Alliance { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new AllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}