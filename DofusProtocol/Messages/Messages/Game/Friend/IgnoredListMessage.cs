using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IgnoredListMessage : Message
    {
        public const uint Id = 5674;

        public IgnoredListMessage(IgnoredInformations[] ignoredList)
        {
            IgnoredList = ignoredList;
        }

        public IgnoredListMessage()
        {
        }

        public override uint MessageId => Id;

        public IgnoredInformations[] IgnoredList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) IgnoredList.Count());
            for (var ignoredListIndex = 0; ignoredListIndex < IgnoredList.Count(); ignoredListIndex++)
            {
                var objectToSend = IgnoredList[ignoredListIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var ignoredListCount = reader.ReadUShort();
            IgnoredList = new IgnoredInformations[ignoredListCount];
            for (var ignoredListIndex = 0; ignoredListIndex < ignoredListCount; ignoredListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                IgnoredList[ignoredListIndex] = objectToAdd;
            }
        }
    }
}