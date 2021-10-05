using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StartupActionAddMessage : Message
    {
        public const uint Id = 6538;

        public StartupActionAddMessage(StartupActionAddObject newAction)
        {
            NewAction = newAction;
        }

        public StartupActionAddMessage()
        {
        }

        public override uint MessageId => Id;

        public StartupActionAddObject NewAction { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            NewAction.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewAction = new StartupActionAddObject();
            NewAction.Deserialize(reader);
        }
    }
}