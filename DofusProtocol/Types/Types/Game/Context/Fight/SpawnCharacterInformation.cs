using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class SpawnCharacterInformation : SpawnInformation
    {
        public const short Id = 574;

        public override short TypeId
        {
            get { return Id; }
        }

        public string name;
        public uint level;


        public SpawnCharacterInformation()
        {
        }

        public SpawnCharacterInformation(string name, uint level)
        {
            this.name = name;
            this.level = level;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
            writer.WriteVarShort((short) level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
            level = reader.ReadVarUShort();
        }
    }
}