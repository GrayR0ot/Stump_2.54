using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StorageObjectUpdateMessage : Message
    {
        public const uint Id = 5647;

        public StorageObjectUpdateMessage(ObjectItem @object)
        {
            this.@object = @object;
        }

        public StorageObjectUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem @object { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            @object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            @object = new ObjectItem();
            @object.Deserialize(reader);
        }
    }
}