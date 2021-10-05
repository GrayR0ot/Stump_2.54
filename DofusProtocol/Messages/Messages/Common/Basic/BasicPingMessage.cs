using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BasicPingMessage : Message
    {
        public const uint Id = 182;

        public BasicPingMessage(bool quiet)
        {
            Quiet = quiet;
        }

        public BasicPingMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Quiet { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Quiet);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quiet = reader.ReadBoolean();
        }
    }
}