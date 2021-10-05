using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachSavedMessage : Message
    {
        public const uint Id = 6798;

        public BreachSavedMessage(bool saved)
        {
            Saved = saved;
        }

        public BreachSavedMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Saved { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Saved);
        }

        public override void Deserialize(IDataReader reader)
        {
            Saved = reader.ReadBoolean();
        }
    }
}