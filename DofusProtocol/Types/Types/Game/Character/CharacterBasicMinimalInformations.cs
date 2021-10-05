using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterBasicMinimalInformations : AbstractCharacterInformation
    {
        public new const short Id = 503;

        public CharacterBasicMinimalInformations(double objectId, string name)
        {
            ObjectId = objectId;
            Name = name;
        }

        public CharacterBasicMinimalInformations()
        {
        }

        public override short TypeId => Id;

        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}