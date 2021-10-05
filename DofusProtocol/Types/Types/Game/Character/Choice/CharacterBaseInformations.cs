using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public new const short Id = 45;

        public CharacterBaseInformations(double objectId, string name, uint level, EntityLook entityLook, sbyte breed,
            bool sex)
        {
            ObjectId = objectId;
            Name = name;
            Level = level;
            EntityLook = entityLook;
            Breed = breed;
            Sex = sex;
        }

        public CharacterBaseInformations()
        {
        }

        public override short TypeId => Id;

        public bool Sex { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Sex = reader.ReadBoolean();
        }
    }
}