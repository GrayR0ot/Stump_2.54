using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StatedElementUpdatedMessage : Message
    {
        public const uint Id = 5709;

        public StatedElementUpdatedMessage(StatedElement statedElement)
        {
            StatedElement = statedElement;
        }

        public StatedElementUpdatedMessage()
        {
        }

        public override uint MessageId => Id;

        public StatedElement StatedElement { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            StatedElement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            StatedElement = new StatedElement();
            StatedElement.Deserialize(reader);
        }
    }
}