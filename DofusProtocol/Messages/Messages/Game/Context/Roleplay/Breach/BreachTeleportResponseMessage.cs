using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachTeleportResponseMessage : Message
    {
        public const uint Id = 6816;

        public BreachTeleportResponseMessage(bool teleported)
        {
            Teleported = teleported;
        }

        public BreachTeleportResponseMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Teleported { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Teleported);
        }

        public override void Deserialize(IDataReader reader)
        {
            Teleported = reader.ReadBoolean();
        }
    }
}