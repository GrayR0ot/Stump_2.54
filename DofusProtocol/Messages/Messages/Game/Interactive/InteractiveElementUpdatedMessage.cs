using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InteractiveElementUpdatedMessage : Message
    {
        public const uint Id = 5708;

        public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement)
        {
            InteractiveElement = interactiveElement;
        }

        public InteractiveElementUpdatedMessage()
        {
        }

        public override uint MessageId => Id;

        public InteractiveElement InteractiveElement { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            InteractiveElement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            InteractiveElement = new InteractiveElement();
            InteractiveElement.Deserialize(reader);
        }
    }
}