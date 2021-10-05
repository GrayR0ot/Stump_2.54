using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
    {
        public new const uint Id = 6337;

        public ExchangeBidHouseInListUpdatedMessage(int itemUID, int objGenericId, ObjectEffect[] effects,
            ulong[] prices)
        {
            ItemUID = itemUID;
            ObjGenericId = objGenericId;
            Effects = effects;
            Prices = prices;
        }

        public ExchangeBidHouseInListUpdatedMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}