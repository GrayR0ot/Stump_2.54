using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EntitiesInformationMessage : Message
    {
        public const uint Id = 6775;

        public EntitiesInformationMessage(EntityInformation[] entities)
        {
            Entities = entities;
        }

        public EntitiesInformationMessage()
        {
        }

        public override uint MessageId => Id;

        public EntityInformation[] Entities { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Entities.Count());
            for (var entitiesIndex = 0; entitiesIndex < Entities.Count(); entitiesIndex++)
            {
                var objectToSend = Entities[entitiesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var entitiesCount = reader.ReadUShort();
            Entities = new EntityInformation[entitiesCount];
            for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
            {
                var objectToAdd = new EntityInformation();
                objectToAdd.Deserialize(reader);
                Entities[entitiesIndex] = objectToAdd;
            }
        }
    }
}