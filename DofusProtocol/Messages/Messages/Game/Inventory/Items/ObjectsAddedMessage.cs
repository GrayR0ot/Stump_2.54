using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectsAddedMessage : Message
    {
        public const uint Id = 6033;

        public ObjectsAddedMessage(ObjectItem[] @object)
        {
            this.@object = @object;
        }

        public ObjectsAddedMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem[] @object { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) @object.Count());
            for (var objectIndex = 0; objectIndex < @object.Count(); objectIndex++)
            {
                var objectToSend = @object[objectIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectCount = reader.ReadUShort();
            @object = new ObjectItem[objectCount];
            for (var objectIndex = 0; objectIndex < objectCount; objectIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                @object[objectIndex] = objectToAdd;
            }
        }
    }
}