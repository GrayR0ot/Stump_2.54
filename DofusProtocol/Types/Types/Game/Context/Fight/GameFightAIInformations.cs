using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightAIInformations : GameFightFighterInformations
    {
        public new const short Id = 151;

        public GameFightAIInformations(double contextualId, EntityLook look, EntityDispositionInformations disposition,
            sbyte teamId, sbyte wave, bool alive, GameFightMinimalStats stats, ushort[] previousPositions)
        {
            ContextualId = contextualId;
            Disposition = disposition;
            Look = look;
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
        }

        public GameFightAIInformations()
        {
        }

        public override short TypeId => Id;

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