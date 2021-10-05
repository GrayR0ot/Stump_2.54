using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BasicWhoIsRequestMessage : Message
    {
        public const uint Id = 181;

        public BasicWhoIsRequestMessage(bool verbose, string search)
        {
            Verbose = verbose;
            Search = search;
        }

        public BasicWhoIsRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Verbose { get; set; }
        public string Search { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Verbose);
            writer.WriteUTF(Search);
        }

        public override void Deserialize(IDataReader reader)
        {
            Verbose = reader.ReadBoolean();
            Search = reader.ReadUTF();
        }
    }
}