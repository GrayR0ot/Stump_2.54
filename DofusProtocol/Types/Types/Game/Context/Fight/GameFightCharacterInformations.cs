using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public new const short Id = 46;

        public GameFightCharacterInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions, string name, PlayerStatus status, short leagueId,
            int ladderPosition, bool hiddenInPrefight, ushort level, ActorAlignmentInformations alignmentInfos,
            sbyte breed, bool sex)
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
            Level = level;
            AlignmentInfos = alignmentInfos;
            Breed = breed;
            Sex = sex;
        }

        public GameFightCharacterInformations()
        {
        }

        public override short TypeId => Id;

        public ushort Level { get; set; }
        public ActorAlignmentInformations AlignmentInfos { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(Level);
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