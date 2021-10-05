using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightFighterNamedInformations : GameFightFighterInformations
    {
        public new const short Id = 158;

        public GameFightFighterNamedInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions, string name, PlayerStatus status, short leagueId,
            int ladderPosition, bool hiddenInPrefight)
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
        }

        public GameFightFighterNamedInformations()
        {
        }

        public override short TypeId => Id;

        public string Name { get; set; }
        public PlayerStatus Status { get; set; }
        public short LeagueId { get; set; }
        public int LadderPosition { get; set; }
        public bool HiddenInPrefight { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            Status.Serialize(writer);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
            writer.WriteBoolean(HiddenInPrefight);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
            HiddenInPrefight = reader.ReadBoolean();
        }
    }
}