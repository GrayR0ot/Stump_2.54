using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public const short Id = 48;

        public override short TypeId
        {
            get { return Id; }
        }

        public uint FirstNameId;
        public uint LastNameId;
        public byte Level;


        public GameFightTaxCollectorInformations()
        {
        }

        public GameFightTaxCollectorInformations(double contextualId, Types.EntityDispositionInformations disposition,
            Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave,
            Types.GameFightMinimalStats stats, uint[] previousPositions, uint firstNameId, uint lastNameId, byte level)
            : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
        {
            this.FirstNameId = firstNameId;
            this.LastNameId = lastNameId;
            this.Level = level;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((short) FirstNameId);
            writer.WriteVarShort((short) LastNameId);
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