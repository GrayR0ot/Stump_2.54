using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class UpdateMountIntegerCharacteristic : UpdateMountCharacteristic
    {
        public new const short Id = 537;

        public UpdateMountIntegerCharacteristic(sbyte type, int value)
        {
            Type = type;
            Value = value;
        }

        public UpdateMountIntegerCharacteristic()
        {
        }

        public override short TypeId => Id;

        public int Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadInt();
        }
    }
}