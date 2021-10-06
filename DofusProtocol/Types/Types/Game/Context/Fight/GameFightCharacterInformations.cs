using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public const short Id = 46;

        public override short TypeId
        {
            get { return Id; }
        }

        public uint Level;
        public ActorAlignmentInformations AlignmentInfos;
        public sbyte Breed;
        public bool Sex;


        public GameFightCharacterInformations()
        {
        }

        public GameFightCharacterInformations(double contextualId, EntityDispositionInformations disposition,
            EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightMinimalStats stats,
            uint[] previousPositions, string name, PlayerStatus status, int leagueId, int ladderPosition,
            bool hiddenInPrefight, uint level, ActorAlignmentInformations alignmentInfos, sbyte breed, bool sex)
            : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions, name, status, leagueId,
                ladderPosition, hiddenInPrefight)
        {
            this.Level = level;
            this.AlignmentInfos = alignmentInfos;
            this.Breed = breed;
            this.Sex = sex;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((short) Level);
            AlignmentInfos.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUShort();
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }
    }
}