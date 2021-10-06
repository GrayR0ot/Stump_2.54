using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightMutantInformations : GameFightFighterNamedInformations
    {
        public const short Id = 50;

        public override short TypeId
        {
            get { return Id; }
        }

        public sbyte PowerLevel;


        public GameFightMutantInformations()
        {
        }

        public GameFightMutantInformations(double contextualId, Types.EntityDispositionInformations disposition,
            Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave,
            Types.GameFightMinimalStats stats, uint[] previousPositions, string name, Types.PlayerStatus status,
            int leagueId, int ladderPosition, bool hiddenInPrefight, sbyte powerLevel)
            : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions, name, status, leagueId,
                ladderPosition, hiddenInPrefight)
        {
            this.PowerLevel = powerLevel;
        }


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