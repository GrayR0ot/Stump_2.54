using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeMountsPaddockAddMessage : Message
    {
        public const uint Id = 6561;

        public ExchangeMountsPaddockAddMessage(MountClientData[] mountDescription)
        {
            MountDescription = mountDescription;
        }

        public ExchangeMountsPaddockAddMessage()
        {
        }

        public override uint MessageId => Id;

        public MountClientData[] MountDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) MountDescription.Count());
            for (var mountDescriptionIndex = 0;
                mountDescriptionIndex < MountDescription.Count();
                mountDescriptionIndex++)
            {
                var objectToSend = MountDescription[mountDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var mountDescriptionCount = reader.ReadUShort();
            MountDescription = new MountClientData[mountDescriptionCount];
            for (var mountDescriptionIndex = 0; mountDescriptionIndex < mountDescriptionCount; mountDescriptionIndex++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                MountDescription[mountDescriptionIndex] = objectToAdd;
            }
        }
    }
}