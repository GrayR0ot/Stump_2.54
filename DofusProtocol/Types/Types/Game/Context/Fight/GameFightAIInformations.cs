using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightAIInformations : GameFightFighterInformations
    {
        public const short Id = 151;

        public override short TypeId
        {
            get { return Id; }
        }


        public GameFightAIInformations()
        {
        }

        public GameFightAIInformations(double contextualId, Types.EntityDispositionInformations disposition,
            Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave,
            Types.GameFightMinimalStats stats, uint[] previousPositions)
            : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
        {
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}