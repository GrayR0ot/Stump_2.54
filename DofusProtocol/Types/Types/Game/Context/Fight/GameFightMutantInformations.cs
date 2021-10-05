using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightMutantInformations : GameFightFighterNamedInformations
    {
        public new const short Id = 50;

        public GameFightMutantInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions, string name, PlayerStatus status, short leagueId,
            int ladderPosition, bool hiddenInPrefight, sbyte powerLevel)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
            Name = name;
            Status = status;
            LeagueId = leagueId;
            LadderPosition = ladderPosition;
            HiddenInPrefight = hiddenInPrefight;
            PowerLevel = powerLevel;
        }

        public GameFightMutantInformations()
        {
        }

        public override short TypeId => Id;

        public sbyte PowerLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PowerLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PowerLevel = reader.ReadSByte();
        }
    }
}