using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameContextMoveMultipleElementsMessage : Message
    {
        public const uint Id = 254;

        public GameContextMoveMultipleElementsMessage(EntityMovementInformations[] movements)
        {
            Movements = movements;
        }

        public GameContextMoveMultipleElementsMessage()
        {
        }

        public override uint MessageId => Id;

        public EntityMovementInformations[] Movements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Movements.Count());
            for (var movementsIndex = 0; movementsIndex < Movements.Count(); movementsIndex++)
            {
                var objectToSend = Movements[movementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var movementsCount = reader.ReadUShort();
            Movements = new EntityMovementInformations[movementsCount];
            for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
            {
                var objectToAdd = new EntityMovementInformations();
                objectToAdd.Deserialize(reader);
                Movements[movementsIndex] = objectToAdd;
            }
        }
    }
}