using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class BaseSpawnMonsterInformation : SpawnInformation
    {
        public const short Id = 582;

        public override short TypeId
        {
            get { return Id; }
        }

        public uint creatureGenericId;


        public BaseSpawnMonsterInformation()
        {
        }

        public BaseSpawnMonsterInformation(uint creatureGenericId)
        {
            this.creatureGenericId = creatureGenericId;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((short)creatureGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            creatureGenericId = reader.ReadVarUShort();
        }
    }
}