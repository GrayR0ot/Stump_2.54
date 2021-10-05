using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
    {
        public new const uint Id = 5589;

        public CompassUpdatePartyMemberMessage(sbyte type, MapCoordinates coords, ulong memberId, bool active)
        {
            Type = type;
            Coords = coords;
            MemberId = memberId;
            Active = active;
        }

        public CompassUpdatePartyMemberMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong MemberId { get; set; }
        public bool Active { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(MemberId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberId = reader.ReadVarULong();
            Active = reader.ReadBoolean();
        }
    }
}