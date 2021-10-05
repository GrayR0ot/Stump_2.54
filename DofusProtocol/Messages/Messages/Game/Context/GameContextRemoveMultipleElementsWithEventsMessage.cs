using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
    {
        public new const uint Id = 6416;

        public GameContextRemoveMultipleElementsWithEventsMessage(double[] elementsIds, byte[] elementEventIds)
        {
            ElementsIds = elementsIds;
            ElementEventIds = elementEventIds;
        }

        public GameContextRemoveMultipleElementsWithEventsMessage()
        {
        }

        public override uint MessageId => Id;

        public byte[] ElementEventIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) ElementEventIds.Count());
            for (var elementEventIdsIndex = 0; elementEventIdsIndex < ElementEventIds.Count(); elementEventIdsIndex++)
                writer.WriteByte(ElementEventIds[elementEventIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var elementEventIdsCount = reader.ReadUShort();
            ElementEventIds = new byte[elementEventIdsCount];
            for (var elementEventIdsIndex = 0; elementEventIdsIndex < elementEventIdsCount; elementEventIdsIndex++)
                ElementEventIds[elementEventIdsIndex] = reader.ReadByte();
        }
    }
}