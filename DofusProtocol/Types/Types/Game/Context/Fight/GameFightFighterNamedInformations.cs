using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightFighterNamedInformations : GameFightFighterInformations
    {
        public const short Id = 158;

        public override short TypeId
        {
            get { return Id; }
        }

        public string Name;
        public Types.PlayerStatus Status;
        public int LeagueId;
        public int LadderPosition;
        public bool HiddenInPrefight;


        public GameFightFighterNamedInformations()
        {
        }

        public GameFightFighterNamedInformations(double contextualId, Types.EntityDispositionInformations disposition,
            Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave,
            Types.GameFightMinimalStats stats, uint[] previousPositions, string name, Types.PlayerStatus status,
            int leagueId, int ladderPosition, bool hiddenInPrefight)
            : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
        {
            this.Name = name;
            this.Status = status;
            this.LeagueId = leagueId;
            this.LadderPosition = ladderPosition;
            this.HiddenInPrefight = hiddenInPrefight;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            Status.Serialize(writer);
            writer.WriteVarShort((short) LeagueId);
            writer.WriteInt(LadderPosition);
            writer.WriteBoolean(HiddenInPrefight);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Status = new Types.PlayerStatus();
            Status.Deserialize(reader);
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
            HiddenInPrefight = reader.ReadBoolean();
        }
    }
}