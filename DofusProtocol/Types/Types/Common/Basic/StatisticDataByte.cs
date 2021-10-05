using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class StatisticDataByte : StatisticData
    {
        public new const short Id = 486;

        public StatisticDataByte(sbyte value)
        {
            Value = value;
        }

        public StatisticDataByte()
        {
        }

        public override short TypeId => Id;

        public sbyte Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadSByte();
        }
    }
}