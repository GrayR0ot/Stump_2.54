using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachExitResponseMessage : Message
    {
        public const uint Id = 6814;

        public BreachExitResponseMessage(bool exited)
        {
            Exited = exited;
        }

        public BreachExitResponseMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Exited { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Exited);
        }

        public override void Deserialize(IDataReader reader)
        {
            Exited = reader.ReadBoolean();
        }
    }
}