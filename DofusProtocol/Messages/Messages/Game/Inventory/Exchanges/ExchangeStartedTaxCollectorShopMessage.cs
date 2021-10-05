using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartedTaxCollectorShopMessage : Message
    {
        public const uint Id = 6664;

        public ExchangeStartedTaxCollectorShopMessage(ObjectItem[] objects, ulong kamas)
        {
            Objects = objects;
            Kamas = kamas;
        }

        public ExchangeStartedTaxCollectorShopMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem[] Objects { get; set; }
        public ulong Kamas { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Objects.Count());
            for (var objectsIndex = 0; objectsIndex < Objects.Count(); objectsIndex++)
            {
                var objectToSend = Objects[objectsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteVarULong(Kamas);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectsCount = reader.ReadUShort();
            Objects = new ObjectItem[objectsCount];
            for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Objects[objectsIndex] = objectToAdd;
            }

            Kamas = reader.ReadVarULong();
        }
    }
}