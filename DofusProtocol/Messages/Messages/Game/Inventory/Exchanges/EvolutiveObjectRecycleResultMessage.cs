using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EvolutiveObjectRecycleResultMessage : Message
    {
        public const uint Id = 6779;

        public EvolutiveObjectRecycleResultMessage(RecycledItem[] recycledItems)
        {
            RecycledItems = recycledItems;
        }

        public EvolutiveObjectRecycleResultMessage()
        {
        }

        public override uint MessageId => Id;

        public RecycledItem[] RecycledItems { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) RecycledItems.Count());
            for (var recycledItemsIndex = 0; recycledItemsIndex < RecycledItems.Count(); recycledItemsIndex++)
            {
                var objectToSend = RecycledItems[recycledItemsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var recycledItemsCount = reader.ReadUShort();
            RecycledItems = new RecycledItem[recycledItemsCount];
            for (var recycledItemsIndex = 0; recycledItemsIndex < recycledItemsCount; recycledItemsIndex++)
            {
                var objectToAdd = new RecycledItem();
                objectToAdd.Deserialize(reader);
                RecycledItems[recycledItemsIndex] = objectToAdd;
            }
        }
    }
}