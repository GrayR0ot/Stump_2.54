using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterSpellModification
    {
        public const short Id = 215;

        public CharacterSpellModification(sbyte modificationType, ushort spellId, CharacterBaseCharacteristic value)
        {
            ModificationType = modificationType;
            SpellId = spellId;
            Value = value;
        }

        public CharacterSpellModification()
        {
        }

        public virtual short TypeId => Id;

        public sbyte ModificationType { get; set; }
        public ushort SpellId { get; set; }
        public CharacterBaseCharacteristic Value { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ModificationType);
            writer.WriteVarUShort(SpellId);
            Value.Serialize(writer);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ModificationType = reader.ReadSByte();
            SpellId = reader.ReadVarUShort();
            Value = new CharacterBaseCharacteristic();
            Value.Deserialize(reader);
        }
    }
}