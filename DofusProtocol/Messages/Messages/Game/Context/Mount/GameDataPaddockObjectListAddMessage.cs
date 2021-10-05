using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameDataPaddockObjectListAddMessage : Message
    {
        public const uint Id = 5992;

        public GameDataPaddockObjectListAddMessage(PaddockItem[] paddockItemDescription)
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public GameDataPaddockObjectListAddMessage()
        {
        }

        public override uint MessageId => Id;

        public PaddockItem[] PaddockItemDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PaddockItemDescription.Count());
            for (var paddockItemDescriptionIndex = 0;
                paddockItemDescriptionIndex < PaddockItemDescription.Count();
                paddockItemDescriptionIndex++)
            {
                var objectToSend = PaddockItemDescription[paddockItemDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var paddockItemDescriptionCount = reader.ReadUShort();
            PaddockItemDescription = new PaddockItem[paddockItemDescriptionCount];
            for (var paddockItemDescriptionIndex = 0;
                paddockItemDescriptionIndex < paddockItemDescriptionCount;
                paddockItemDescriptionIndex++)
            {
                var objectToAdd = new PaddockItem();
                objectToAdd.Deserialize(reader);
                PaddockItemDescription[paddockItemDescriptionIndex] = objectToAdd;
            }
        }
    }
}