using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public new const short Id = 48;

        public GameFightTaxCollectorInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions, ushort firstNameId, ushort lastNameId, byte level)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            Level = level;
        }

        public GameFightTaxCollectorInformations()
        {
        }

        public override short TypeId => Id;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public byte Level { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(FirstNameId);
            writer.WriteVarUShort(LastNameId);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUShort();
            LastNameId = reader.ReadVarUShort();
            Level = reader.ReadByte();
        }
    }
}