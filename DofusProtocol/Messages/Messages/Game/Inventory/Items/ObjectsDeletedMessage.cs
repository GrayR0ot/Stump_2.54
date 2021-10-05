using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectsDeletedMessage : Message
    {
        public const uint Id = 6034;

        public ObjectsDeletedMessage(uint[] objectUID)
        {
            ObjectUID = objectUID;
        }

        public ObjectsDeletedMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] ObjectUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectUID.Count());
            for (var objectUIDIndex = 0; objectUIDIndex < ObjectUID.Count(); objectUIDIndex++)
                writer.WriteVarUInt(ObjectUID[objectUIDIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectUIDCount = reader.ReadUShort();
            ObjectUID = new uint[objectUIDCount];
            for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++)
                ObjectUID[objectUIDIndex] = reader.ReadVarUInt();
        }
    }
}