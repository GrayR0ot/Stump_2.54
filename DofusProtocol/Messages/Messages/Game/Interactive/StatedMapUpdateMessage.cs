using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StatedMapUpdateMessage : Message
    {
        public const uint Id = 5716;

        public StatedMapUpdateMessage(StatedElement[] statedElements)
        {
            StatedElements = statedElements;
        }

        public StatedMapUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public StatedElement[] StatedElements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) StatedElements.Count());
            for (var statedElementsIndex = 0; statedElementsIndex < StatedElements.Count(); statedElementsIndex++)
            {
                var objectToSend = StatedElements[statedElementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var statedElementsCount = reader.ReadUShort();
            StatedElements = new StatedElement[statedElementsCount];
            for (var statedElementsIndex = 0; statedElementsIndex < statedElementsCount; statedElementsIndex++)
            {
                var objectToAdd = new StatedElement();
                objectToAdd.Deserialize(reader);
                StatedElements[statedElementsIndex] = objectToAdd;
            }
        }
    }
}