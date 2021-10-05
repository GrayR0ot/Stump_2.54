using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class StatisticDataBoolean : StatisticData
    {
        public new const short Id = 482;

        public StatisticDataBoolean(bool value)
        {
            Value = value;
        }

        public StatisticDataBoolean()
        {
        }

        public override short TypeId => Id;

        public bool Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadBoolean();
        }
    }
}