using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
    {
        public new const short Id = 163;

        public CharacterMinimalPlusLookInformations(double objectId, string name, uint level, EntityLook entityLook,
            sbyte breed)
        {
            ObjectId = objectId;
            Name = name;
            Level = level;
            EntityLook = entityLook;
            Breed = breed;
        }

        public CharacterMinimalPlusLookInformations()
        {
        }

        public override short TypeId => Id;

        public EntityLook EntityLook { get; set; }
        public sbyte Breed { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            EntityLook.Serialize(writer);
            writer.WriteSByte(Breed);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EntityLook = new EntityLook();
            EntityLook.Deserialize(reader);
            Breed = reader.ReadSByte();
        }
    }
}