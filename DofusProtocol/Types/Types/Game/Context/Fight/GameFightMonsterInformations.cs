using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightMonsterInformations : GameFightAIInformations
    {
        public new const short Id = 29;

        public GameFightMonsterInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions, ushort creatureGenericId, sbyte creatureGrade,
            short creatureLevel)
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
        }

        public GameFightMonsterInformations()
        {
        }

        public override short TypeId => Id;

        public ushort CreatureGenericId { get; set; }
        public sbyte CreatureGrade { get; set; }
        public short CreatureLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(CreatureGenericId);
            writer.WriteSByte(CreatureGrade);
            writer.WriteShort(CreatureLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadVarUShort();
            CreatureGrade = reader.ReadSByte();
            CreatureLevel = reader.ReadShort();
        }
    }
}