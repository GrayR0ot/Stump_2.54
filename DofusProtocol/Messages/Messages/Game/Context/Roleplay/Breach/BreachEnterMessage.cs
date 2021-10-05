using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachEnterMessage : Message
    {
        public const uint Id = 6810;

        public BreachEnterMessage(ulong owner)
        {
            Owner = owner;
        }

        public BreachEnterMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong Owner { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(Owner);
        }

        public override void Deserialize(IDataReader reader)
        {
            Owner = reader.ReadVarULong();
        }
    }
}