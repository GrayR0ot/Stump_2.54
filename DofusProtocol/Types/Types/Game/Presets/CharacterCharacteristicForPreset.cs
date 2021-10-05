using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterCharacteristicForPreset : SimpleCharacterCharacteristicForPreset
    {
        public new const short Id = 539;

        public CharacterCharacteristicForPreset(string keyword, short @base, short additionnal, short stuff)
        {
            Keyword = keyword;
            this.@base = @base;
            Additionnal = additionnal;
            Stuff = stuff;
        }

        public CharacterCharacteristicForPreset()
        {
        }

        public override short TypeId => Id;

        public short Stuff { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Stuff);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Stuff = reader.ReadVarShort();
        }
    }
}