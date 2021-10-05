using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeObjectsModifiedMessage : ExchangeObjectMessage
    {
        public new const uint Id = 6533;

        public ExchangeObjectsModifiedMessage(bool remote, ObjectItem[] @object)
        {
            Remote = remote;
            this.@object = @object;
        }

        public ExchangeObjectsModifiedMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem[] @object { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) @object.Count());
            for (var objectIndex = 0; objectIndex < @object.Count(); objectIndex++)
            {
                var objectToSend = @object[objectIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
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