using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{

    public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
    {

        public const uint Id = 6337;
        public override uint MessageId
        {
            get { return Id; }
        }



        public ExchangeBidHouseInListUpdatedMessage()
        {
        }

        public ExchangeBidHouseInListUpdatedMessage(int itemUID, uint objectGID, int objectType, ObjectEffect[] effects, ulong[] prices)
            : base(itemUID, objectGID, objectType, effects, prices)
        {
        }
        

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