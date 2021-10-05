using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public new const short Id = 110;

        public CharacterMinimalInformations(double objectId, string name, uint level)
        {
            ObjectId = objectId;
            Name = name;
            Level = level;
        }

        public CharacterMinimalInformations()
        {
        }

        public override short TypeId => Id;

        public uint Level { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUInt();
        }
    }
}