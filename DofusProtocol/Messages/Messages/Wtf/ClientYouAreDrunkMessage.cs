using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ClientYouAreDrunkMessage : DebugInClientMessage
    {
        public new const uint Id = 6594;

        public ClientYouAreDrunkMessage(sbyte level, string message)
        {
            this.level = level;
            this.message = message;
        }

        public ClientYouAreDrunkMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}