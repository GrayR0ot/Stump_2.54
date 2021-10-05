using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
    {
        public new const short Id = 203;

        public GameFightMonsterWithAlignmentInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions, ushort creatureGenericId, sbyte creatureGrade,
            short creatureLevel, ActorAlignmentInformations alignmentInfos)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
            CreatureGenericId = creatureGenericId;
            CreatureGrade = creatureGrade;
            CreatureLevel = creatureLevel;
            AlignmentInfos = alignmentInfos;
        }

        public GameFightMonsterWithAlignmentInformations()
        {
        }

        public override short TypeId => Id;

        public ActorAlignmentInformations AlignmentInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
        }
    }
}