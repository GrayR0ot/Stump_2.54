using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class StatisticDataInt : StatisticData
    {
        public new const short Id = 485;

        public StatisticDataInt(int value)
        {
            Value = value;
        }

        public StatisticDataInt()
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