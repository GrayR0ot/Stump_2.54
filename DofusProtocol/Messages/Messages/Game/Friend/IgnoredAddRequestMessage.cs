using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IgnoredAddRequestMessage : Message
    {
        public const uint Id = 5673;

        public IgnoredAddRequestMessage(string name, bool session)
        {
            Name = name;
            Session = session;
        }

        public IgnoredAddRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }
        public bool Session { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Session = reader.ReadBoolean();
        }
    }
}