using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class SpawnCompanionInformation : SpawnInformation
    {
        public const short Id = 573;

        public override short TypeId
        {
            get { return Id; }
        }

        public sbyte ModelId;
        public uint Level;
        public double SummonerId;
        public double OwnerId;


        public SpawnCompanionInformation()
        {
        }

        public SpawnCompanionInformation(sbyte modelId, uint level, double summonerId, double ownerId)
        {
            this.ModelId = modelId;
            this.Level = level;
            this.SummonerId = summonerId;
            this.OwnerId = ownerId;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(ModelId);
            writer.WriteVarShort((short) Level);
            writer.WriteDouble(SummonerId);
            writer.WriteDouble(OwnerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ModelId = reader.ReadSByte();
            Level = reader.ReadVarUShort();
            SummonerId = reader.ReadDouble();
            OwnerId = reader.ReadDouble();
        }
    }
}