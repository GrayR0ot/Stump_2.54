using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BasicWhoIsNoMatchMessage : Message
    {
        public const uint Id = 179;

        public BasicWhoIsNoMatchMessage(string search)
        {
            Search = search;
        }

        public BasicWhoIsNoMatchMessage()
        {
        }

        public override uint MessageId => Id;

        public string Search { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Search);
        }

        public override void Deserialize(IDataReader reader)
        {
            Search = reader.ReadUTF();
        }
    }
}