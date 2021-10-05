using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectModifiedMessage : Message
    {
        public const uint Id = 3029;

        public ObjectModifiedMessage(ObjectItem @object)
        {
            this.@object = @object;
        }

        public ObjectModifiedMessage()
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