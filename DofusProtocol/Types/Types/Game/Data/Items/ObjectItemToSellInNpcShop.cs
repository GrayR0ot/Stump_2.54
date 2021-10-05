using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
    {
        public new const short Id = 352;

        public ObjectItemToSellInNpcShop(ushort objectGID, ObjectEffect[] effects, ulong objectPrice,
            string buyCriterion)
        {
            ObjectGID = objectGID;
            Effects = effects;
            ObjectPrice = objectPrice;
            BuyCriterion = buyCriterion;
        }

        public ObjectItemToSellInNpcShop()
        {
        }

        public override short TypeId => Id;

        public ulong ObjectPrice { get; set; }
        public string BuyCriterion { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(ObjectPrice);
            writer.WriteUTF(BuyCriterion);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectPrice = reader.ReadVarULong();
            BuyCriterion = reader.ReadUTF();
        }
    }
}