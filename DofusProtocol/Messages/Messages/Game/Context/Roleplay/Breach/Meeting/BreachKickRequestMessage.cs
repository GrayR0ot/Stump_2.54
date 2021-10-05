using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachKickRequestMessage : Message
    {
        public const uint Id = 6804;

        public BreachKickRequestMessage(ulong target)
        {
            Target = target;
        }

        public BreachKickRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong Target { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(Target);
        }

        public override void Deserialize(IDataReader reader)
        {
            Target = reader.ReadVarULong();
        }
    }
}