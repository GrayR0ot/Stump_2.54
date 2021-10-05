using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BasicWhoAmIRequestMessage : Message
    {
        public const uint Id = 5664;

        public BasicWhoAmIRequestMessage(bool verbose)
        {
            Verbose = verbose;
        }

        public BasicWhoAmIRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Verbose { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(IDataReader reader)
        {
            Verbose = reader.ReadBoolean();
        }
    }
}