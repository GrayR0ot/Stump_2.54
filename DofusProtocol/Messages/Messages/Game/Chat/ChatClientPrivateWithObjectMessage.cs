using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
    {
        public new const uint Id = 852;

        public ChatClientPrivateWithObjectMessage(string content, string receiver, ObjectItem[] objects)
        {
            Content = content;
            Receiver = receiver;
            Objects = objects;
        }

        public ChatClientPrivateWithObjectMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem[] Objects { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Objects.Count());
            for (var objectsIndex = 0; objectsIndex < Objects.Count(); objectsIndex++)
            {
                var objectToSend = Objects[objectsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var objectsCount = reader.ReadUShort();
            Objects = new ObjectItem[objectsCount];
            for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Objects[objectsIndex] = objectToAdd;
            }
        }
    }
}