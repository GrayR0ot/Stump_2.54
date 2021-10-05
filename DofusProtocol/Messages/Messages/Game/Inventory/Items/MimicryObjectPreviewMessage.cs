using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MimicryObjectPreviewMessage : Message
    {
        public const uint Id = 6458;

        public MimicryObjectPreviewMessage(ObjectItem result)
        {
            Result = result;
        }

        public MimicryObjectPreviewMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem Result { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Result.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = new ObjectItem();
            Result.Deserialize(reader);
        }
    }
}