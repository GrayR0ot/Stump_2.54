using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public new const short Id = 143;

        public GameFightFighterInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
        }

        public GameFightFighterInformations()
        {
        }

        public override short TypeId => Id;

        public sbyte TeamId { get; set; }
        public sbyte Wave { get; set; }
        public bool Alive { get; set; }
        public GameFightMinimalStats Stats { get; set; }
        public ushort[] PreviousPositions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(TeamId);
            writer.WriteSByte(Wave);
            writer.WriteBoolean(Alive);
            writer.WriteShort(Stats.TypeId);
            Stats.Serialize(writer);
            writer.WriteShort((short) PreviousPositions.Count());
            for (var previousPositionsIndex = 0;
                previousPositionsIndex < PreviousPositions.Count();
                previousPositionsIndex++) writer.WriteVarUShort(PreviousPositions[previousPositionsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TeamId = reader.ReadSByte();
            Wave = reader.ReadSByte();
            Alive = reader.ReadBoolean();
            Stats = ProtocolTypeManager.GetInstance<GameFightMinimalStats>(reader.ReadShort());
            Stats.Deserialize(reader);
            var previousPositionsCount = reader.ReadUShort();
            PreviousPositions = new ushort[previousPositionsCount];
            for (var previousPositionsIndex = 0;
                previousPositionsIndex < previousPositionsCount;
                previousPositionsIndex++) PreviousPositions[previousPositionsIndex] = reader.ReadVarUShort();
        }
    }
}