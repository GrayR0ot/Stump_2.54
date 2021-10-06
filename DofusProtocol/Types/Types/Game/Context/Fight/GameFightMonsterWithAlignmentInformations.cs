using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
    {
        public const short Id = 203;

        public override short TypeId
        {
            get { return Id; }
        }

        public Types.ActorAlignmentInformations AlignmentInfos;


        public GameFightMonsterWithAlignmentInformations()
        {
        }

        public GameFightMonsterWithAlignmentInformations(double contextualId,
            Types.EntityDispositionInformations disposition, Types.EntityLook look,
            Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave, Types.GameFightMinimalStats stats,
            uint[] previousPositions, uint creatureGenericId, sbyte creatureGrade, short creatureLevel,
            Types.ActorAlignmentInformations alignmentInfos)
            : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions, creatureGenericId,
                creatureGrade, creatureLevel)
        {
            this.AlignmentInfos = alignmentInfos;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new Types.ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
        }
    }
}