using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
    {
        public new const uint Id = 6236;

        public ExchangeStartedWithStorageMessage(sbyte exchangeType, uint storageMaxSlot)
        {
            ExchangeType = exchangeType;
            StorageMaxSlot = storageMaxSlot;
        }

        public ExchangeStartedWithStorageMessage()
        {
        }

        public override uint MessageId => Id;

        public uint StorageMaxSlot { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(StorageMaxSlot);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StorageMaxSlot = reader.ReadVarUInt();
        }
    }
}