using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterRemodelingInformation : AbstractCharacterInformation
    {
        public new const short Id = 479;

        public CharacterRemodelingInformation(ulong objectId, string name, sbyte breed, bool sex, ushort cosmeticId,
            int[] colors)
        {
            ObjectId = objectId;
            Name = name;
            Breed = breed;
            Sex = sex;
            CosmeticId = cosmeticId;
            Colors = colors;
        }

        public CharacterRemodelingInformation()
        {
        }

        public override short TypeId => Id;

        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort CosmeticId { get; set; }
        public int[] Colors { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarUShort(CosmeticId);
            writer.WriteShort((short) Colors.Count());
            for (var colorsIndex = 0; colorsIndex < Colors.Count(); colorsIndex++) writer.WriteInt(Colors[colorsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            CosmeticId = reader.ReadVarUShort();
            var colorsCount = reader.ReadUShort();
            Colors = new int[colorsCount];
            for (var colorsIndex = 0; colorsIndex < colorsCount; colorsIndex++) Colors[colorsIndex] = reader.ReadInt();
        }
    }
}