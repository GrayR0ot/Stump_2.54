using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightUpdateTeamMessage : Message
    {
        public const uint Id = 5572;

        public GameFightUpdateTeamMessage(ushort fightId, FightTeamInformations team)
        {
            FightId = fightId;
            Team = team;
        }

        public GameFightUpdateTeamMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort FightId { get; set; }
        public FightTeamInformations Team { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(FightId);
            Team.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUShort();
            Team = new FightTeamInformations();
            Team.Deserialize(reader);
        }
    }
}