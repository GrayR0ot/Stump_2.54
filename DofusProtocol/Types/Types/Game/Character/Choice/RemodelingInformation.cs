using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class RemodelingInformation
    {
        public const short Id = 480;

        public RemodelingInformation(string name, sbyte breed, bool sex, ushort cosmeticId, int[] colors)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            CosmeticId = cosmeticId;
            Colors = colors;
        }

        public RemodelingInformation()
        {
        }

        public virtual short TypeId => Id;

        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort CosmeticId { get; set; }
        public int[] Colors { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarUShort(CosmeticId);
            writer.WriteShort((short) Colors.Count());
            for (var colorsIndex = 0; colorsIndex < Colors.Count(); colorsIndex++) writer.WriteInt(Colors[colorsIndex]);
        }

        public virtual void Deserialize(IDataReader reader)
        {
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