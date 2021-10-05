using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameContextRemoveMultipleElementsMessage : Message
    {
        public const uint Id = 252;

        public GameContextRemoveMultipleElementsMessage(double[] elementsIds)
        {
            ElementsIds = elementsIds;
        }

        public GameContextRemoveMultipleElementsMessage()
        {
        }

        public override uint MessageId => Id;

        public double[] ElementsIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ElementsIds.Count());
            for (var elementsIdsIndex = 0; elementsIdsIndex < ElementsIds.Count(); elementsIdsIndex++)
                writer.WriteDouble(ElementsIds[elementsIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var elementsIdsCount = reader.ReadUShort();
            ElementsIds = new double[elementsIdsCount];
            for (var elementsIdsIndex = 0; elementsIdsIndex < elementsIdsCount; elementsIdsIndex++)
                ElementsIds[elementsIdsIndex] = reader.ReadDouble();
        }
    }
}