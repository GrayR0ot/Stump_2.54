using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
    {
        public new const uint Id = 6532;

        public ExchangeObjectsRemovedMessage(bool remote, uint[] objectUID)
        {
            Remote = remote;
            ObjectUID = objectUID;
        }

        public ExchangeObjectsRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] ObjectUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) ObjectUID.Count());
            for (var objectUIDIndex = 0; objectUIDIndex < ObjectUID.Count(); objectUIDIndex++)
                writer.WriteVarUInt(ObjectUID[objectUIDIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var objectUIDCount = reader.ReadUShort();
            ObjectUID = new uint[objectUIDCount];
            for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++)
                ObjectUID[objectUIDIndex] = reader.ReadVarUInt();
        }
    }
}