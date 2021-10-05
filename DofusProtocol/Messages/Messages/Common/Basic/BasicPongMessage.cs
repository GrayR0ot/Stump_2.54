using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BasicPongMessage : Message
    {
        public const uint Id = 183;

        public BasicPongMessage(bool quiet)
        {
            Quiet = quiet;
        }

        public BasicPongMessage()
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