using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartOkMountWithOutPaddockMessage : Message
    {
        public const uint Id = 5991;

        public ExchangeStartOkMountWithOutPaddockMessage(MountClientData[] stabledMountsDescription)
        {
            StabledMountsDescription = stabledMountsDescription;
        }

        public ExchangeStartOkMountWithOutPaddockMessage()
        {
        }

        public override uint MessageId => Id;

        public MountClientData[] StabledMountsDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) StabledMountsDescription.Count());
            for (var stabledMountsDescriptionIndex = 0;
                stabledMountsDescriptionIndex < StabledMountsDescription.Count();
                stabledMountsDescriptionIndex++)
            {
                var objectToSend = StabledMountsDescription[stabledMountsDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var stabledMountsDescriptionCount = reader.ReadUShort();
            StabledMountsDescription = new MountClientData[stabledMountsDescriptionCount];
            for (var stabledMountsDescriptionIndex = 0;
                stabledMountsDescriptionIndex < stabledMountsDescriptionCount;
                stabledMountsDescriptionIndex++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                StabledMountsDescription[stabledMountsDescriptionIndex] = objectToAdd;
            }
        }
    }
}