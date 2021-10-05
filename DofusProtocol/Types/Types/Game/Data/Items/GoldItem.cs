using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GoldItem : Item
    {
        public new const short Id = 123;

        public GoldItem(ulong sum)
        {
            Sum = sum;
        }

        public GoldItem()
        {
        }

        public override short TypeId => Id;

        public ulong Sum { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(Sum);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Sum = reader.ReadVarULong();
        }
    }
}