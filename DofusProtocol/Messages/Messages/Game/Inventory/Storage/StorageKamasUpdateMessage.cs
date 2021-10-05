using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StorageKamasUpdateMessage : Message
    {
        public const uint Id = 5645;

        public StorageKamasUpdateMessage(ulong kamasTotal)
        {
            KamasTotal = kamasTotal;
        }

        public StorageKamasUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong KamasTotal { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(KamasTotal);
        }

        public override void Deserialize(IDataReader reader)
        {
            KamasTotal = reader.ReadVarULong();
        }
    }
}