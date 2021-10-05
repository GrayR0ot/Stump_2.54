using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightJoinRequestMessage : Message
    {
        public const uint Id = 701;

        public GameFightJoinRequestMessage(double fighterId, ushort fightId)
        {
            FighterId = fighterId;
            FightId = fightId;
        }

        public GameFightJoinRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public double FighterId { get; set; }
        public ushort FightId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FighterId);
            writer.WriteVarUShort(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FighterId = reader.ReadDouble();
            FightId = reader.ReadVarUShort();
        }
    }
}