using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HavenBagFurnituresMessage : Message
    {
        public const uint Id = 6634;

        public HavenBagFurnituresMessage(HavenBagFurnitureInformation[] furnituresInfos)
        {
            FurnituresInfos = furnituresInfos;
        }

        public HavenBagFurnituresMessage()
        {
        }

        public override uint MessageId => Id;

        public HavenBagFurnitureInformation[] FurnituresInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) FurnituresInfos.Count());
            for (var furnituresInfosIndex = 0; furnituresInfosIndex < FurnituresInfos.Count(); furnituresInfosIndex++)
            {
                var objectToSend = FurnituresInfos[furnituresInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var furnituresInfosCount = reader.ReadUShort();
            FurnituresInfos = new HavenBagFurnitureInformation[furnituresInfosCount];
            for (var furnituresInfosIndex = 0; furnituresInfosIndex < furnituresInfosCount; furnituresInfosIndex++)
            {
                var objectToAdd = new HavenBagFurnitureInformation();
                objectToAdd.Deserialize(reader);
                FurnituresInfos[furnituresInfosIndex] = objectToAdd;
            }
        }
    }
}