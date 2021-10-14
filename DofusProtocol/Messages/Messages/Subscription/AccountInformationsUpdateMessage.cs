using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{

    public class AccountInformationsUpdateMessage : Message
    {

        public const uint Id = 6740;
        public override uint MessageId
        {
            get { return Id; }
        }

        public double subscriptionEndDate;
        

        public AccountInformationsUpdateMessage()
        {
        }

        public AccountInformationsUpdateMessage(double subscriptionEndDate)
        {
            this.subscriptionEndDate = subscriptionEndDate;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteDouble(subscriptionEndDate);
            

        }

        public override void Deserialize(IDataReader reader)
        {

            subscriptionEndDate = reader.ReadDouble();
            

        }


    }


}