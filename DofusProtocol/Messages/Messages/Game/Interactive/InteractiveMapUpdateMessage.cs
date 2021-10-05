using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class InteractiveMapUpdateMessage : Message
    {
        public const uint Id = 5002;

        public InteractiveMapUpdateMessage(InteractiveElement[] interactiveElements)
        {
            InteractiveElements = interactiveElements;
        }

        public InteractiveMapUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public InteractiveElement[] InteractiveElements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) InteractiveElements.Count());
            for (var interactiveElementsIndex = 0;
                interactiveElementsIndex < InteractiveElements.Count();
                interactiveElementsIndex++)
            {
                var objectToSend = InteractiveElements[interactiveElementsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var interactiveElementsCount = reader.ReadUShort();
            InteractiveElements = new InteractiveElement[interactiveElementsCount];
            for (var interactiveElementsIndex = 0;
                interactiveElementsIndex < interactiveElementsCount;
                interactiveElementsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                InteractiveElements[interactiveElementsIndex] = objectToAdd;
            }
        }
    }
}