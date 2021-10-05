using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AcquaintancesListMessage : Message
    {
        public const uint Id = 6820;

        public AcquaintancesListMessage(AcquaintanceInformation[] acquaintanceList)
        {
            AcquaintanceList = acquaintanceList;
        }

        public AcquaintancesListMessage()
        {
        }

        public override uint MessageId => Id;

        public AcquaintanceInformation[] AcquaintanceList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) AcquaintanceList.Count());
            for (var acquaintanceListIndex = 0;
                acquaintanceListIndex < AcquaintanceList.Count();
                acquaintanceListIndex++)
            {
                var objectToSend = AcquaintanceList[acquaintanceListIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var acquaintanceListCount = reader.ReadUShort();
            AcquaintanceList = new AcquaintanceInformation[acquaintanceListCount];
            for (var acquaintanceListIndex = 0; acquaintanceListIndex < acquaintanceListCount; acquaintanceListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<AcquaintanceInformation>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                AcquaintanceList[acquaintanceListIndex] = objectToAdd;
            }
        }
    }
}