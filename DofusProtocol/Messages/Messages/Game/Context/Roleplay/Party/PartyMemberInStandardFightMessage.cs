using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyMemberInStandardFightMessage : AbstractPartyMemberInFightMessage
    {
        public new const uint Id = 6826;

        public PartyMemberInStandardFightMessage(uint partyId, sbyte reason, ulong memberId, int memberAccountId,
            string memberName, ushort fightId, short timeBeforeFightStart, MapCoordinatesExtended fightMap)
        {
            PartyId = partyId;
            Reason = reason;
            MemberId = memberId;
            MemberAccountId = memberAccountId;
            MemberName = memberName;
            FightId = fightId;
            TimeBeforeFightStart = timeBeforeFightStart;
            FightMap = fightMap;
        }

        public PartyMemberInStandardFightMessage()
        {
        }

        public override uint MessageId => Id;

        public MapCoordinatesExtended FightMap { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            FightMap.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FightMap = new MapCoordinatesExtended();
            FightMap.Deserialize(reader);
        }
    }
}