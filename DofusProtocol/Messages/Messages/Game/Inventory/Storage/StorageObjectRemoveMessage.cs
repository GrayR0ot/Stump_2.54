using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StorageObjectRemoveMessage : Message
    {
        public const uint Id = 5648;

        public StorageObjectRemoveMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public StorageObjectRemoveMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUInt();
        }
    }
}