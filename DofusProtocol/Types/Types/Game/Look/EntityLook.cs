using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class EntityLook
    {
        public const short Id = 55;

        public EntityLook(ushort bonesId, ushort[] skins, int[] indexedColors, short[] scales, SubEntity[] subentities)
        {
            BonesId = bonesId;
            Skins = skins;
            IndexedColors = indexedColors;
            Scales = scales;
            Subentities = subentities;
        }

        public EntityLook()
        {
        }

        public virtual short TypeId => Id;

        public ushort BonesId { get; set; }
        public ushort[] Skins { get; set; }
        public int[] IndexedColors { get; set; }
        public short[] Scales { get; set; }
        public SubEntity[] Subentities { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(BonesId);
            writer.WriteShort((short) Skins.Count());
            for (var skinsIndex = 0; skinsIndex < Skins.Count(); skinsIndex++) writer.WriteVarUShort(Skins[skinsIndex]);
            writer.WriteShort((short) IndexedColors.Count());
            for (var indexedColorsIndex = 0; indexedColorsIndex < IndexedColors.Count(); indexedColorsIndex++)
                writer.WriteInt(IndexedColors[indexedColorsIndex]);
            writer.WriteShort((short) Scales.Count());
            for (var scalesIndex = 0; scalesIndex < Scales.Count(); scalesIndex++)
                writer.WriteVarShort(Scales[scalesIndex]);
            writer.WriteShort((short) Subentities.Count());
            for (var subentitiesIndex = 0; subentitiesIndex < Subentities.Count(); subentitiesIndex++)
            {
                var objectToSend = Subentities[subentitiesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            BonesId = reader.ReadVarUShort();
            var skinsCount = reader.ReadUShort();
            Skins = new ushort[skinsCount];
            for (var skinsIndex = 0; skinsIndex < skinsCount; skinsIndex++) Skins[skinsIndex] = reader.ReadVarUShort();
            var indexedColorsCount = reader.ReadUShort();
            IndexedColors = new int[indexedColorsCount];
            for (var indexedColorsIndex = 0; indexedColorsIndex < indexedColorsCount; indexedColorsIndex++)
                IndexedColors[indexedColorsIndex] = reader.ReadInt();
            var scalesCount = reader.ReadUShort();
            Scales = new short[scalesCount];
            for (var scalesIndex = 0; scalesIndex < scalesCount; scalesIndex++)
                Scales[scalesIndex] = reader.ReadVarShort();
            var subentitiesCount = reader.ReadUShort();
            Subentities = new SubEntity[subentitiesCount];
            for (var subentitiesIndex = 0; subentitiesIndex < subentitiesCount; subentitiesIndex++)
            {
                var objectToAdd = new SubEntity();
                objectToAdd.Deserialize(reader);
                Subentities[subentitiesIndex] = objectToAdd;
            }
        }
    }
}