using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightExternalInformations
    {
        public const short Id = 117;
        public ushort fightId;
        public bool fightSpectatorLocked;
        public int fightStart;
        public FightTeamLightInformations[] fightTeams;
        public FightOptionsInformations[] fightTeamsOptions;
        public sbyte fightType;

        public FightExternalInformations(ushort fightId, sbyte fightType, int fightStart, bool fightSpectatorLocked,
            FightTeamLightInformations[] fightTeams, FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightStart = fightStart;
            this.fightSpectatorLocked = fightSpectatorLocked;
            this.fightTeams = fightTeams;
            this.fightTeamsOptions = fightTeamsOptions;
        }

        public FightExternalInformations()
        {
        }

        public virtual short TypeId => Id;

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(fightId);
            writer.WriteSByte(fightType);
            writer.WriteInt(fightStart);
            writer.WriteBoolean(fightSpectatorLocked);
            for (var i = 0; i < 2; i++) fightTeams[i].Serialize(writer);
            for (var i = 0; i < 2; i++) fightTeamsOptions[i].Serialize(writer);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadVarUShort();
            fightType = reader.ReadSByte();
            fightStart = reader.ReadInt();
            fightSpectatorLocked = reader.ReadBoolean();
            fightTeams = new FightTeamLightInformations[2];
            for (var i = 0; i < 2; i++)
            {
                fightTeams[i] = new FightTeamLightInformations();
                fightTeams[i].Deserialize(reader);
            }

            fightTeamsOptions = new FightOptionsInformations[2];
            for (var i = 0; i < 2; i++)
            {
                fightTeamsOptions[i] = new FightOptionsInformations();
                fightTeamsOptions[i].Deserialize(reader);
            }
        }
    }
}