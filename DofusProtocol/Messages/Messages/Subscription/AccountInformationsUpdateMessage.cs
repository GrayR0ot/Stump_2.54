using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AccountInformationsUpdateMessage : Message
    {
        public const uint Id = 6740;

        public AccountInformationsUpdateMessage(double subscriptionEndDate, double unlimitedRestatEndDate)
        {
            SubscriptionEndDate = subscriptionEndDate;
            UnlimitedRestatEndDate = unlimitedRestatEndDate;
        }

        public AccountInformationsUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public double SubscriptionEndDate { get; set; }
        public double UnlimitedRestatEndDate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SubscriptionEndDate);
            writer.WriteDouble(UnlimitedRestatEndDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubscriptionEndDate = reader.ReadDouble();
            UnlimitedRestatEndDate = reader.ReadDouble();
        }
    }
}