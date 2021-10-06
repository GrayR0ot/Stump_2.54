using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Types
{
    public class SpawnMonsterInformation : BaseSpawnMonsterInformation
    {
        public const short Id = 572;

        public override short TypeId
        {
            get { return Id; }
        }

        public sbyte creatureGrade;


        public SpawnMonsterInformation()
        {
        }

        public SpawnMonsterInformation(uint creatureGenericId, sbyte creatureGrade)
            : base(creatureGenericId)
        {
            this.creatureGrade = creatureGrade;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(creatureGrade);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            creatureGrade = reader.ReadSByte();
        }
    }
}