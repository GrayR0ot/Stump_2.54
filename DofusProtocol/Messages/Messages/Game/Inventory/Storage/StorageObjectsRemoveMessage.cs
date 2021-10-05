using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StorageObjectsRemoveMessage : Message
    {
        public const uint Id = 6035;

        public StorageObjectsRemoveMessage(uint[] objectUIDList)
        {
            ObjectUIDList = objectUIDList;
        }

        public StorageObjectsRemoveMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] ObjectUIDList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectUIDList.Count());
            for (var objectUIDListIndex = 0; objectUIDListIndex < ObjectUIDList.Count(); objectUIDListIndex++)
                writer.WriteVarUInt(ObjectUIDList[objectUIDListIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectUIDListCount = reader.ReadUShort();
            ObjectUIDList = new uint[objectUIDListCount];
            for (var objectUIDListIndex = 0; objectUIDListIndex < objectUIDListCount; objectUIDListIndex++)
                ObjectUIDList[objectUIDListIndex] = reader.ReadVarUInt();
        }
    }
}