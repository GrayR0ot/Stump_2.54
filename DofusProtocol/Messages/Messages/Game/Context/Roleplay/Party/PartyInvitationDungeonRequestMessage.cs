using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
    {
        public new const uint Id = 6245;

        public PartyInvitationDungeonRequestMessage(string name, ushort dungeonId)
        {
            Name = name;
            DungeonId = dungeonId;
        }

        public PartyInvitationDungeonRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort DungeonId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(DungeonId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarUShort();
        }
    }
}