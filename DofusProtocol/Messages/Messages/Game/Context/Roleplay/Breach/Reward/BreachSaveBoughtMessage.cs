using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachSaveBoughtMessage : Message
    {
        public const uint Id = 6788;

        public BreachSaveBoughtMessage(bool bought)
        {
            Bought = bought;
        }

        public BreachSaveBoughtMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Bought { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bought = reader.ReadBoolean();
        }
    }
}