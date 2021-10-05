using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IgnoredAddedMessage : Message
    {
        public const uint Id = 5678;

        public IgnoredAddedMessage(IgnoredInformations ignoreAdded, bool session)
        {
            IgnoreAdded = ignoreAdded;
            Session = session;
        }

        public IgnoredAddedMessage()
        {
        }

        public override uint MessageId => Id;

        public IgnoredInformations IgnoreAdded { get; set; }
        public bool Session { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(IgnoreAdded.TypeId);
            IgnoreAdded.Serialize(writer);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            IgnoreAdded = ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
            IgnoreAdded.Deserialize(reader);
            Session = reader.ReadBoolean();
        }
    }
}