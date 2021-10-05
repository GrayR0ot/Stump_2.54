using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobBookSubscriptionMessage : Message
    {
        public const uint Id = 6593;

        public JobBookSubscriptionMessage(JobBookSubscription[] subscriptions)
        {
            Subscriptions = subscriptions;
        }

        public JobBookSubscriptionMessage()
        {
        }

        public override uint MessageId => Id;

        public JobBookSubscription[] Subscriptions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Subscriptions.Count());
            for (var subscriptionsIndex = 0; subscriptionsIndex < Subscriptions.Count(); subscriptionsIndex++)
            {
                var objectToSend = Subscriptions[subscriptionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var subscriptionsCount = reader.ReadUShort();
            Subscriptions = new JobBookSubscription[subscriptionsCount];
            for (var subscriptionsIndex = 0; subscriptionsIndex < subscriptionsCount; subscriptionsIndex++)
            {
                var objectToAdd = new JobBookSubscription();
                objectToAdd.Deserialize(reader);
                Subscriptions[subscriptionsIndex] = objectToAdd;
            }
        }
    }
}