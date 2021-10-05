using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
    {
        public new const uint Id = 6262;

        public PartyInvitationDungeonDetailsMessage(uint partyId, sbyte partyType, string partyName, ulong fromId,
            string fromName, ulong leaderId, PartyInvitationMemberInformations[] members,
            PartyGuestInformations[] guests, ushort dungeonId, bool[] playersDungeonReady)
        {
            PartyId = partyId;
            PartyType = partyType;
            PartyName = partyName;
            FromId = fromId;
            FromName = fromName;
            LeaderId = leaderId;
            Members = members;
            Guests = guests;
            DungeonId = dungeonId;
            PlayersDungeonReady = playersDungeonReady;
        }

        public PartyInvitationDungeonDetailsMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort DungeonId { get; set; }
        public bool[] PlayersDungeonReady { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(DungeonId);
            writer.WriteShort((short) PlayersDungeonReady.Count());
            for (var playersDungeonReadyIndex = 0;
                playersDungeonReadyIndex < PlayersDungeonReady.Count();
                playersDungeonReadyIndex++) writer.WriteBoolean(PlayersDungeonReady[playersDungeonReadyIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarUShort();
            var playersDungeonReadyCount = reader.ReadUShort();
            PlayersDungeonReady = new bool[playersDungeonReadyCount];
            for (var playersDungeonReadyIndex = 0;
                playersDungeonReadyIndex < playersDungeonReadyCount;
                playersDungeonReadyIndex++) PlayersDungeonReady[playersDungeonReadyIndex] = reader.ReadBoolean();
        }
    }
}