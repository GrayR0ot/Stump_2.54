using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StorageInventoryContentMessage : InventoryContentMessage
    {
        public new const uint Id = 5646;

        public StorageInventoryContentMessage(ObjectItem[] objects, ulong kamas)
        {
            Objects = objects;
            Kamas = kamas;
        }

        public StorageInventoryContentMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}